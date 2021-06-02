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
        private IGeneric<Review> _repo;
        private TalabatContext _db;

        public ReviewsController(IGeneric<Review> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/Reviews
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Review>>))]
        public async Task<ActionResult<List<Review>>> Get()
        {
            List<Review> reviews = await _repo.RetriveAllAsync();
            if (reviews == null)
                return BadRequest();
            if (reviews.Count == 0)
                return NoContent();
            return Ok(reviews);
        }

        // GET api/Reviews/5
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();
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
            if (Review == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ReviewCategoryId = _db.ReviewCategories.Find(Review.ReviewCategoryId);
            var UserId = _db.Clients.Find(Review.UserId);
            var StoreId = _db.Stores.Find(Review.StoreId);

            if (ReviewCategoryId == null || UserId == null || StoreId == null)
                return BadRequest();

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
            if (id <= 0)
                return BadRequest();

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
            if (Review == null|| Review.ReviewId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ReviewCategoryId = _db.ReviewCategories.Find(Review.ReviewCategoryId);
            var UserId = _db.Clients.Find(Review.UserId);
            var StoreId = _db.Stores.Find(Review.StoreId);

            if (ReviewCategoryId == null || UserId == null || StoreId == null)
                return BadRequest();

            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            var affected = await _repo.PatchAsync(Review);
            if (affected == null)
            {
                return BadRequest();
            }
            return new NoContentResult();

        }
    }
}