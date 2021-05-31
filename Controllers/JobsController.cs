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
    public class JobsController : ControllerBase
    {
        private IGeneric<Job> _repo;
        private IGeneric<JobCategory> _repoJobCategory;
        private IGeneric<JobLocation> _repoJobLocation;
        private IGeneric<JobType> _repoJobType;
        private IGeneric<JobPeriod> _repoJobPeriod;
        private TalabatContext _db;

        public JobsController(IGeneric<Job> repo, IGeneric<JobCategory> repoJobCategory, IGeneric<JobLocation> repoJobLocation, IGeneric<JobType> repoJobType, IGeneric<JobPeriod> repoJobPeriod, TalabatContext db)
        {
            _repo = repo;
            _repoJobCategory = repoJobCategory;
            _repoJobLocation = repoJobLocation;
            _repoJobType = repoJobType;
            _repoJobPeriod = repoJobPeriod;
            _db = db;
        }


        // GET: api/Jobs
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Job>>))]
        public async Task<ActionResult<List<Job>>> Get()
        {
            var jobs = await _repo.RetriveAllAsync();
            if (jobs.Count == 0)
            {
                return NoContent();
            }

            return Ok(jobs);
        }

        // GET api/Jobs/5
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

            var job = await _repo.RetriveAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // POST api/Jobs
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Job job)
        {
            if (job == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobCategory = await _repoJobCategory.RetriveAsync(job.JobCategoryId);
            var jobLocation = await _repoJobLocation.RetriveAsync(job.JobLocationId);
            var jobType = await _repoJobType.RetriveAsync(job.JobTypeId);
            var jobPeriod = await _repoJobPeriod.RetriveAsync(job.JobPeriodId);
            
            if (jobCategory == null || jobLocation == null || jobType == null || jobPeriod == null)
            {
                return BadRequest();
            }

            var added = await _repo.CreatAsync(job);
            if (added == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/Jobs/5
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

        // Patch api/Jobs/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Patch(int id, [FromBody] Job job)
        {
            if (job == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobCategory = await _repoJobCategory.RetriveAsync(job.JobCategoryId);
            var jobLocation = await _repoJobLocation.RetriveAsync(job.JobLocationId);
            var jobType = await _repoJobType.RetriveAsync(job.JobTypeId);
            var jobPeriod = await _repoJobPeriod.RetriveAsync(job.JobPeriodId);

            if (jobCategory == null || jobLocation == null || jobType == null || jobPeriod == null)
            {
                return BadRequest();
            }

            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            var patched= await _repo.PatchAsync(job);
            if (patched == null)
            {
                return BadRequest("Failed to Update!");
            }

            return NoContent();
        }
    }
}
