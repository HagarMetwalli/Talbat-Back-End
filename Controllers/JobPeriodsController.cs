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
    public class JobPeriodsController : ControllerBase
    {
        private IGeneric<JobPeriod> _repo;
        private TalabatContext _db;

        public JobPeriodsController(IGeneric<JobPeriod> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }


        // GET: api/JobPeriods
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<JobPeriod>>))]
        public async Task<ActionResult<List<JobPeriod>>> Get()
        {
            var jobPeriods = await _repo.RetriveAllAsync();
            if (jobPeriods.Count == 0)
            {
                return NoContent();
            }

            return Ok(jobPeriods);
        }

        // GET api/JobPeriods/5
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

            var jobPeriod = await _repo.RetriveAsync(id);
            if (jobPeriod == null)
            {
                return NotFound();
            }

            return Ok(jobPeriod);
        }

        // POST api/JobPeriods
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] JobPeriod jobPeriod)
        {
            if (jobPeriod == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var added = await _repo.CreatAsync(jobPeriod);
            if (added == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/JobPeriods/5
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

        // Patch api/JobPeriods/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Patch(int id, [FromBody] JobPeriod jobPeriod)
        {
            if (jobPeriod == null)
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

            var patched= await _repo.PatchAsync(jobPeriod);
            if (patched == null)
            {
                return BadRequest("Failed to Update!");
            }

            return NoContent();
        }
    }
}
