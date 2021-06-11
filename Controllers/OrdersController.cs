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

        public OrdersController(IOrderRelated repo, IUserService<Client> repoClient, IStoreService repoStore)
        {
            _repo = repo;
            _repoClient = repoClient;
            _repoStore = repoStore;
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

        // POST api/Orders
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _repoClient.RetriveAsync(order.ClientId);
            var store = await _repoStore.RetriveAsync(order.StoreId);
            int years = DateTime.Now.Year - client.ClientDateOfBirth.Year;

            if (client == null || store == null || years <= 12)
            {
                return BadRequest();
            }

            var added = await _repo.CreatAsync(order);
            if (added == null)
            {
                return BadRequest();
            }

            //store.StoreOrdersNumber += 1;
            return Ok();
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
