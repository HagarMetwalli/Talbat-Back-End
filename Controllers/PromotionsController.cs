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
    public class PromotionsController : ControllerBase
    {
        private IPromotionRelatedService _repo;
        private TalabatContext _db;

        public PromotionsController(IPromotionRelatedService repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }

        // GET: api/Offers
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Promotion>))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Get()
        {
            var offers = await _repo.RetriveAllAsync();

            if (offers == null)
            {
                return NoContent();
            }
            return Ok(offers);
        }

        // GET api/Offers/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            Promotion offer = await _repo.RetriveAsync(id);

            if (offer == null)
            {
                return NotFound();
            }

            return Ok(offer);
        }

        [HttpGet]
        [Route("OfferStore")]
        [ProducesResponseType(200, Type = typeof(Store))]
        [ProducesResponseType(404)]
        public IActionResult OfferStore(int Id)
        {
            var offerStore = _repo.RetrieveOfferStoreAsync(Id);

            if (offerStore == null)
            {
                return NotFound();
            }

            return Ok(offerStore);
        }

        // POST api/Offers
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Promotion offer)
        {
            if (offer == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Promotion added = await _repo.CreatAsync(offer);

            if (added == null)
            {
                return BadRequest();
            }

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

            //Why nullable boolean?
            bool deleted = await _repo.DeleteAsync(id);
            ///////////////////////////////////

            if (deleted)
            {
                return new NoContentResult();//204 No Content
            }
            else
            {
                return BadRequest($"Offer {id} was found but failed to delete");
            }
        }
        // Patch api/Offers/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Patch(int id, [FromBody] Promotion offer)
        {
            if (offer == null)
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
            await _repo.PatchAsync(offer);
            return new NoContentResult();

        }

    }//end controller
}
