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
    public class ItemReviewsController : ControllerBase
    {
        private IGeneric<ItemReview> _repo;
        private TalabatContext _db;

        public ItemReviewsController(IGeneric<ItemReview> repo,TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/itemreviews
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<ItemReview>>))]
        public async Task<ActionResult<List<Client>>> Get()
        {
            List<ItemReview> itemReviews = await _repo.RetriveAllAsync();
            if (itemReviews.Count == 0)
            {
                return NoContent();
            }
            if (itemReviews == null)
            {
                return BadRequest();
            }
            return Ok(itemReviews);
        }

        // GET api/itemreviews/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            ItemReview itemReview = await _repo.RetriveAsync(id);
            if (itemReview == null)
            {
                return NotFound();
            }
            return Ok(itemReview);
        }

        // POST api/itemreviews
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] ItemReview itemReview)
        {
            var ratestatusId = _db.RateStatuses.Find(itemReview.RateStatusId);
            if (itemReview == null || ratestatusId == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ItemReview added = await _repo.CreatAsync(itemReview);
            if (added == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        //Patch api/itemreviews/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ItemReview>> Patch(int id, [FromBody] ItemReview itemReview)
        {
            var ratestatusId = _db.RateStatuses.Find(itemReview.RateStatusId);
            if (id <= 0 || itemReview == null ||ratestatusId ==null || itemReview.ItemId != id)
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
            var _itemReview = await _repo.PatchAsync(itemReview);
            if (_itemReview == null)
            {
                return BadRequest();
            }
            return new NoContentResult();
        }

        // DELETE api/itemreviews/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return null;
            }
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
                return BadRequest($"itemreview {id} was found but failed to delete");
            }
        }

    }
}
