using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private IOfferService _repo;
        private TalabatContext _db;

        public OffersController(IOfferService repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/Offers
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Offer>))]
        public async Task<IEnumerable<Offer>> Get() => await _repo.RetriveAllAsync();

        // GET api/Offers/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            Offer Offer = await _repo.RetriveAsync(id);
            if (Offer == null)
                return NotFound();
            return Ok(Offer);
        }

        // POST api/Offers
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Offer Offer)
        {
            var storeId = _db.Stores.Find(Offer.StoreId);

            if (Offer == null || storeId == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Offer added = await _repo.CreatAsync(Offer);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/Offers/5
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
            bool? deleted = await _repo.DeleteAsync(id);
            if (deleted.HasValue && deleted.Value)
            {
                return new NoContentResult();//204 No Content
            }
            else
            {
                return BadRequest($"Offer {id} was found but failed to delete");
            }
        }
        // Patch api/ Offers/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> PatchOffer(int id, [FromBody] Offer Offer)
        {
            var storeid = _db.Stores.Find(Offer.StoreId);
            if (Offer == null || storeid == null || Offer.OfferId != id)
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
            await _repo.UpdateAsync(Offer);
            return new NoContentResult();

        }

        // GET: api/getallstorethathavecopon
        [HttpGet]
        [Route("getallstorethathavecopon")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Store>))]
        public async Task<IEnumerable<Store>> getallstorethathavecopon()
        {
            return await _repo.GetAllStoreThatHaveCopon();
         
        }

        // GET: api/getallcoponesForSpecificStore/2
        [HttpGet]
        [Route("getallcoponesForSpecificStore/{storeid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> getallcoponesForSpecificStore(int storeid)
        {
            var cheack =  _db.Stores.Find(storeid);
            if (cheack == null )
            {
                return BadRequest();
            }
             var copons = await _repo.GetAllCoponsForSpecificStore(storeid);
            if (copons == null || copons.Count() == 0)
                return NotFound();
            return Ok(copons);
        }


        // GET: api/getallstorethathavepromotion
        [HttpGet]
        [Route("getallstorethathavepromotion")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Store>))]
        public async Task<IEnumerable<Store>> getallstorethathavepromotion()
        {
            return await _repo.GetAllStoreThatHavePromotion();

        }

        // GET: api/getallpromotionForSpecificStore/2
        [HttpGet]
        [Route("getallpromotionForSpecificStore/{storeid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> getallpromotionForSpecificStore(int storeid)
        {
            var cheack = _db.Stores.Find(storeid);
            if (cheack == null)
            {
                return BadRequest();
            }
            var Promotion = await _repo.GetAllPromotionForSpecificStore(storeid);
            if (Promotion == null || Promotion.Count() == 0)
                return NotFound();
            return Ok(Promotion);
        }
    }
}