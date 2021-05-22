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
    public class ReviewsController : ControllerBase
    {
        private IGenericService<Review> _repo;
        private TalabatContext _db;

        public ReviewsController(IGenericService<Review> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/Reviews
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<IList<Review>>))]
        public async Task<ActionResult<IList<Review>>> Get()
        {
            IList<Review> reviews = await _repo.RetriveAllAsync();
            if (reviews.Count == 0)
                return NoContent();
            return Ok(reviews);
        }

        // GET api/Reviews/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            Review Review = await _repo.RetriveAsync(id);
            if (Review == null)
                return NotFound();
            return Ok(Review);
        }

        // POST api/Reviews
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Review Review)
        {
            var ReviewCategoryId = _db.ReviewCategories.Find(Review.ReviewCategoryId);
            var UserId = _db.Cities.Find(Review.UserId);
            var StoreId = _db.Stores.Find(Review.StoreId);

            if (Review == null || ReviewCategoryId == null || UserId == null || StoreId == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Review added = await _repo.CreatAsync(Review);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/Reviews/5
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
                return BadRequest($"Review {id} was found but failed to delete");
            }
        }
        // Patch api/ Reviews/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Patch(int id, [FromBody] Review Review)
        {
            var ReviewCategoryId = _db.ReviewCategories.Find(Review.ReviewCategoryId);
            var UserId = _db.Cities.Find(Review.UserId);
            var StoreId = _db.Stores.Find(Review.StoreId);

            if (Review == null || ReviewCategoryId == null || UserId == null || StoreId == null|| Review.ReviewId != id)
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
            await _repo.UpdateAsync(Review);
            return new NoContentResult();

        }
    }
}