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
        private IGenericService<ReviewCategory> _repo;
        private TalabatContext _db;

        public ReviewCategoriesController(IGenericService<ReviewCategory> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/ReviewCategories
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewCategory>))]
        public async Task<IEnumerable<ReviewCategory>> Get() => await _repo.RetriveAllAsync();

        // GET api/ReviewCategories/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
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
            await _repo.UpdateAsync(ReviewCategory);
            return new NoContentResult();

        }
    }
}