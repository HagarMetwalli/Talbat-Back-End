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
    public class JobTypesController : ControllerBase
    {
        private IGeneric<JobType> _repo;
        private TalabatContext _db;

        public JobTypesController(IGeneric<JobType> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }


        // GET: api/JobTypes
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<JobType>>))]
        public async Task<ActionResult<List<JobType>>> Get()
        {
            var jobTypes = await _repo.RetriveAllAsync();
            if (jobTypes.Count == 0)
            {
                return NoContent();
            }

            return Ok(jobTypes);
        }

        // GET api/JobTypes/5
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

            var jobType = await _repo.RetriveAsync(id);
            if (jobType == null)
            {
                return NotFound();
            }

            return Ok(jobType);
        }

        // POST api/JobTypes
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] JobType jobType)
        {
            if (jobType == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var added = await _repo.CreatAsync(jobType);
            if (added == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/JobTypes/5
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

        // Patch api/JobTypes/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Patch(int id, [FromBody] JobType jobType)
        {
            if (jobType == null)
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

            var patched= await _repo.PatchAsync(jobType);
            if (patched == null)
            {
                return BadRequest("Failed to Update!");
            }

            return NoContent();
        }
    }
}
