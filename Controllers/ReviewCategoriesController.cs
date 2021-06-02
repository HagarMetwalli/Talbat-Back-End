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
    public class ReviewCategoriesController : ControllerBase
    {
        private IGeneric<ReviewCategory> _repo;
        private TalabatContext _db;

        public ReviewCategoriesController(IGeneric<ReviewCategory> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/ReviewCategories
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<ReviewCategory>>))]
        public async Task<ActionResult<List<ReviewCategory>>> Get()
        {
            List<ReviewCategory> reviewCategories = await _repo.RetriveAllAsync();
            if (reviewCategories == null)
                return BadRequest();
            if (reviewCategories.Count == 0)
                return NoContent();
            return Ok(reviewCategories);
        }

        // GET api/ReviewCategories/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();
            ReviewCategory ReviewCategory = await _repo.RetriveAsync(id);
            if (ReviewCategory == null)
                return NotFound();
            return Ok(ReviewCategory);
        }

        // POST api/ReviewCategories
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] ReviewCategory ReviewCategory)
        {
           
            if (ReviewCategory == null )
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ReviewCategory added = await _repo.CreatAsync(ReviewCategory);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/ReviewCategories/5
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
                return BadRequest($"ReviewCategory {id} was found but failed to delete");
            }
        }
        // Patch api/ ReviewCategories/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Patch(int id, [FromBody] ReviewCategory ReviewCategory)
        {
            
            if (ReviewCategory == null || ReviewCategory.ReviewCategoryId != id)
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
            var affected=await _repo.PatchAsync(ReviewCategory);
            if (affected == null)
                return BadRequest();
            return new NoContentResult();

        }
    }
}