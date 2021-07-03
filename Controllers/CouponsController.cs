using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private ICouponRelated _repo;
        private TalabatContext _db;

        public CouponsController(ICouponRelated repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }

        // GET: api/Coupons
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Coupon>))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Get()
        {
            var coupons = await _repo.RetriveAllAsync();

            if (coupons == null)
            {
                return NoContent();
            }
            return Ok(coupons);
        }

        // GET api/Coupons/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            Coupon coupon = await _repo.RetriveAsync(id);

            if (coupon == null)
            {
                return NotFound();
            }

            return Ok(coupon);
        }

        // GET: api/Coupons/GetAllStoresHaveCoupns
        [HttpGet]
        [Route("GetAllStoresHaveCoupns")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public IActionResult GetAllStoresHaveCoupns()
        {
            var stores = _repo.RetriveAllSotresHaveCoupons();

            if (stores == null)
            {
                return NoContent();
            }
            return Ok(stores);
        }

        // GET: api/Coupons/GetStoreCouponItems/3
        [HttpGet]
        [Route("GetStoreCouponItems/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public IActionResult GetStoreCouponItems(int id)
        {
            var couponItems = _repo.RetriveAllSotreCouponItems(id);

            if (couponItems == null)
            {
                return NoContent();
            }
            return Ok(couponItems);
        }

        // POST api/Coupons
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Coupon coupon)
        {
            if (coupon == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Coupon added = await _repo.CreatAsync(coupon);

            if (added == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/Coupons/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repo.RetriveAsync(id);

            if (existing == null)
            {
                return NotFound();
            }

            bool deleted = await _repo.DeleteAsync(id);

            if (deleted)
            {
                return new NoContentResult();
            }
            else
            {
                return BadRequest($"Coupon {id} was found but failed to delete");
            }
        }
        // Patch api/Coupons/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Patch(int id, [FromBody] Coupon coupon)
        {
            if (coupon == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _repo.PatchAsync(coupon);
            return new NoContentResult();
        }

        // GET: api/Coupons/GetCouponDiscount
        [HttpGet]
        [Route("GetCouponDiscount/{key}/{clientId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult TotalDiscountValue(string key, int clientId, [FromQuery] List<int> itemsIdList)//, [FromBody] List<Item> itemsList
        {
            if (clientId == 0)//itemsList.Count <= 0 ||
            {
                return BadRequest();
            }
            //var itemsList = new List<Item>();
            
            var discount = _repo.RetrieveCouponDiscountValueAsync(key, itemsIdList, clientId);

            if (discount == 0)
            {
                return NoContent();
            }

            return Ok(discount);
        }

        

    }//end controller
}


// TODO: ||Done|| Add OrderId for ClientCoupon Table to stack client coupon Usage throught 3 parts composite key
// TODO: ||Done|| Apply Coupon route should be full funtional
