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
        private IGeneric<StoreWorkingHour> _repo;
        private TalabatContext _db;

        public StoreWorkingHoursController(IGeneric<StoreWorkingHour> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/StoreWorkingHours
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<StoreWorkingHour>>))]
        public async Task<ActionResult<List<StoreWorkingHour>>> Get()
        {
            List<StoreWorkingHour> storeWorkingHours = await _repo.RetriveAllAsync();
            if (storeWorkingHours == null)
                return BadRequest();
            if (storeWorkingHours.Count == 0)
                return NoContent();
            return Ok(storeWorkingHours);
        }
        // GET api/StoreWorkingHours/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();
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
            if (StoreWorkingHour == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var StoreId = _db.Stores.Find(StoreWorkingHour.StoreId);
            if ( StoreId == null)
                return BadRequest();

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
            bool deleted = await _repo.DeleteAsync(id);
            if (deleted)
            {
                return new NoContentResult();
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
            if (StoreWorkingHour == null || StoreWorkingHour.StoreWorkingHourId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var StoreId = _db.Stores.Find(StoreWorkingHour.StoreId);
            if (StoreId == null)
            {
                return BadRequest();
            }
        
            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            var affected = await _repo.PatchAsync(StoreWorkingHour);
            if (affected == null)
            {
                return BadRequest();
            }
            return new NoContentResult();

        }
    }
}
