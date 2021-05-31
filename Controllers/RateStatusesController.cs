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
    public class RateStatusesController : ControllerBase
    {
        private IGenericService<RateStatus> _repo;
        private TalabatContext _db;

        public RateStatusesController(IGenericService<RateStatus> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/RateStatuses
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<IList<RateStatus>>))]
        public async Task<ActionResult<IList<RateStatus>>> Get()
        {
            IList<RateStatus> rateStatuses = await _repo.RetriveAllAsync();
            if (rateStatuses.Count == 0)
                return NoContent();
            return Ok(rateStatuses);
        }

        // GET api/RateStatuses/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            RateStatus RateStatus = await _repo.RetriveAsync(id);
            if (RateStatus == null)
                return NotFound();
            return Ok(RateStatus);
        }

        // POST api/RateStatuses
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] RateStatus RateStatus)
        {
            

            if (RateStatus == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            RateStatus added = await _repo.CreatAsync(RateStatus);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/RateStatuses/5
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
                return BadRequest($"RateStatus {id} was found but failed to delete");
            }
        }
        // Patch api/ RateStatuses/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> PatchRateStatus(int id, [FromBody] RateStatus RateStatus)
        {
          
            if (RateStatus == null  || RateStatus.RateStatusId != id)
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
            await _repo.UpdateAsync(RateStatus);
            return new NoContentResult();

        }
    }
}