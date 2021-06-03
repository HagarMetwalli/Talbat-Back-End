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
    public class JobLocationsController : ControllerBase
    {
        private IGeneric<JobLocation> _repo;
        private TalabatContext _db;

        public JobLocationsController(IGeneric<JobLocation> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }


        // GET: api/JobLocations
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<JobLocation>>))]
        public async Task<ActionResult<List<JobLocation>>> Get()
        {
            var jobCategories = await _repo.RetriveAllAsync();
            if (jobCategories.Count == 0)
            {
                return NoContent();
            }

            return Ok(jobCategories);
        }

        // GET api/JobLocations/5
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

            var jobLocation = await _repo.RetriveAsync(id);
            if (jobLocation == null)
            {
                return NotFound();
            }

            return Ok(jobLocation);
        }

        // POST api/JobLocations
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] JobLocation jobLocation)
        {
            if (jobLocation == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var added = await _repo.CreatAsync(jobLocation);
            if (added == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/JobLocations/5
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

        // Patch api/JobLocations/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Patch(int id, [FromBody] JobLocation jobLocation)
        {
            if (jobLocation == null)
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

            var patched= await _repo.PatchAsync(jobLocation);
            if (patched == null)
            {
                return BadRequest("Failed to Update!");
            }

            return NoContent();
        }
    }
}
