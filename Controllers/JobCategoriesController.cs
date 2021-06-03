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
    public class JobCategoriesController : ControllerBase
    {
        private IGeneric<JobCategory> _repo;
        private TalabatContext _db;

        public JobCategoriesController(IGeneric<JobCategory> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }


        // GET: api/JobCategories
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<JobCategory>>))]
        public async Task<ActionResult<List<JobCategory>>> Get()
        {
            var jobCategories = await _repo.RetriveAllAsync();
            if (jobCategories.Count == 0)
            {
                return NoContent();
            }

            return Ok(jobCategories);
        }

        // GET api/JobCategories/5
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

            var jobCategory = await _repo.RetriveAsync(id);
            if (jobCategory == null)
            {
                return NotFound();
            }

            return Ok(jobCategory);
        }

        // POST api/JobCategories
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] JobCategory jobCategory)
        {
            if (jobCategory == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var added = await _repo.CreatAsync(jobCategory);
            if (added == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/JobCategories/5
        [HttpDelete("{id}")]
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
                return NoContent();
            }
            else
            {
                return BadRequest($"Delete Failed!");
            }

        }

        // Patch api/JobCategories/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Patch(int id, [FromBody] JobCategory jobCategory)
        {
            if (jobCategory == null)
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

            var patched= await _repo.PatchAsync(jobCategory);
            if (patched == null)
            {
                return BadRequest("Failed to Update!");
            }

            return NoContent();
        }
    }
}
