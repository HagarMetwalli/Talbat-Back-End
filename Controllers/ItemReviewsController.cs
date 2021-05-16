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
        private IGenericService<ItemReview> _repo;

        public ItemReviewsController(IGenericService<ItemReview> repo)
        {
            _repo = repo;
        }
        // GET: api/itemreviews
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ItemReview>))]
        public async Task<IEnumerable<ItemReview>> Get() => await _repo.RetriveAllAsync();

        // GET api/itemreviews/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            ItemReview itemReview = await _repo.RetriveAsync(id);
            if (itemReview == null)
                return NotFound();
            return Ok(itemReview);
        }

        // POST api/itemreviews
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] ItemReview itemReview)
        {
            if (itemReview == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ItemReview added = await _repo.CreatAsync(itemReview);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        //Patch api/itemreviews/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ItemReview>> PatchItemReview(int id, [FromBody] ItemReview itemReview)
        {
            if (itemReview == null || itemReview.ItemId != id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            var _itemReview = await _repo.UpdateAsync(itemReview);
            if (_itemReview == null)
                return BadRequest();

            return new NoContentResult();
        }
        // DELETE api/itemreviews/5
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
                return BadRequest($"itemreview {id} was found but failed to delete");
            }
        }

    }
}
