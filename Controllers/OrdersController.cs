using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderRelated _repo;
        private IUserService<Client> _repoClient;
        private IStoreService _repoStore;
        private IOrderItems _repoOrderItem;
        private ICouponRelated _repoCoupon;

        public OrdersController(IOrderRelated repo, IUserService<Client> repoClient, IStoreService repoStore, IOrderItems repoOrderItem, ICouponRelated repoCoupon)
        {
            _repo = repo;
            _repoClient = repoClient;
            _repoStore = repoStore;
            _repoOrderItem = repoOrderItem;
            _repoCoupon = repoCoupon;
        }




        // GET: api/Orders
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<IList<Country>>))]
        public async Task<ActionResult<List<Client>>> Get()
        {
            var orders =  _repo.RetriveAllAsync();
            if (orders.Count == 0)
            {
                return NoContent();
            }

            return Ok(orders);
        }

        // GET api/Orders/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var order = _repo.RetriveAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // GET api/Orders/GetByClientId/5
        [HttpGet("GetByClientId/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetByClientId(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var orders = _repo.RetriveByClientIdAsync(id);
            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }


        // TODO: ||Done|| Make submit order (Order order, List<Item> itemsList, Coupon coupon= null)
        // TODO: ||Done|| Make Create OrderItems taking list of items not only 1
        // TODO: Add payment Method!

        // POST api/Orders
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        //public async Task<IActionResult> Post([FromBody] Order order, [FromQuery] List<OrderItem> orderItemsList, Coupon coupon = null)   
        public async Task<IActionResult> Post([FromBody] OrderSubmitData o)
        {
            if (o.order == null || o.orderItemsList == null)
            {
                return BadRequest("Param or more are missing!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _repoClient.RetriveAsync(o.order.ClientId);
            var store = await _repoStore.RetriveAsync(o.order.StoreId);
            int years = DateTime.Now.Year - client.ClientDateOfBirth.Year;

            if (client == null || store == null || years <= 12)
            {
                return BadRequest("Reference or more are missing!");
            }

            if (o.coupon != null)
            {
                var itemIdsList = o.orderItemsList.Select(x => x.ItemId).ToList();

                var couponDiscountValue = _repoCoupon.RetrieveCouponDiscountValueAsync(o.coupon.CouponId, itemIdsList, o.order.ClientId);

                if ( (o.order.OrderCost-couponDiscountValue) < 0 )
                {
                    o.order.OrderCost = 0;
                }
                else
                {
                    o.order.OrderCost -= couponDiscountValue;
                }
            }
            // TODO: |ERROR| Not added!! check it
            var orderAdded = await _repo.CreatAsync(o.order);
            if (orderAdded == null)
            {
                return BadRequest("Order is not added due to some corrupted data sent!");
            }

            var orderItemsRes = _repoOrderItem.CreateListAsync(o.orderItemsList);
            if (orderItemsRes == null)
            {
                return BadRequest("Order item or more are not added due to some corrupted data sent!");
            }

            return Ok("Order Added successfully with all it's related Items");
        }


        // DELETE api/Orders/5
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            bool deleted = await _repo.DeleteAsync(id);
            if (deleted)
            {
                return NoContent();
            }
            else
            {
                return BadRequest($"Delete Failed!");
            }

        }

        // Patch api/Order/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Patch(int id, [FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var clientId = _db.Clients.Find(order.ClientId);
            //var storeId = _db.Stores.Find(order.StoreId);
            
            var clientId = _repoClient.RetriveAsync(order.ClientId);
            var storeId = _repoStore.RetriveAsync(order.StoreId);
            
            if (order.OrderId != id || clientId == null || storeId == null)
            {
                return BadRequest();
            }

            var existing = _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            var patched= await _repo.PatchAsync(order);
            if (patched == null)
            {
                return BadRequest("Failed to Update!");
            }

            return NoContent();
        }
    }
}
