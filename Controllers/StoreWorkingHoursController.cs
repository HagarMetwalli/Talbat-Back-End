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
    public class StoreWorkingHoursController : ControllerBase
    {
        private IGenericService<StoreWorkingHour> _repo;
        private TalabatContext _db;

        public StoreWorkingHoursController(IGenericService<StoreWorkingHour> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/StoreWorkingHours
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StoreWorkingHour>))]
        public async Task<IEnumerable<StoreWorkingHour>> Get() => await _repo.RetriveAllAsync();

        // GET api/StoreWorkingHours/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            StoreWorkingHour StoreWorkingHour = await _repo.RetriveAsync(id);
            if (StoreWorkingHour == null)
                return NotFound();
            return Ok(StoreWorkingHour);
        }

        // POST api/StoreWorkingHours
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] StoreWorkingHour StoreWorkingHour)
        {
            var StoreId = _db.Stores.Find(StoreWorkingHour.StoreId);

            if (StoreWorkingHour == null || StoreId == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StoreWorkingHour added = await _repo.CreatAsync(StoreWorkingHour);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/StoreWorkingHours/5
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
                return BadRequest($"StoreWorkingHour {id} was found but failed to delete");
            }
        }
        // Patch api/ StoreWorkingHours/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Patch(int id, [FromBody] StoreWorkingHour StoreWorkingHour)
        {
            var StoreId = _db.Stores.Find(StoreWorkingHour.StoreId);
            if (StoreWorkingHour == null || StoreId == null || StoreWorkingHour.StoreWorkingHourId != id)
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
            await _repo.UpdateAsync(StoreWorkingHour);
            return new NoContentResult();

        }
    }
}
