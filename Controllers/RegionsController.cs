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
    public class RegionsController : ControllerBase
    {
        private IRegions _repo;
        private TalabatContext _db;

        public RegionsController(IRegions repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/Regions
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Region>>))]
        public async Task<ActionResult<List<Region>>> Get()
        {
            List<Region> regions = await _repo.RetriveAllAsync();
            if (regions == null)
                return BadRequest();
            if (regions.Count == 0)
                return NoContent();
            return Ok(regions);
        }

        // GET api/Regions/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();
            Region Region = await _repo.RetriveAsync(id);
            if (Region == null)
                return NotFound();
            return Ok(Region);
        }

        // POST api/Regions
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Region Region)
        {
            if (Region == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Region added = await _repo.CreatAsync(Region);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/Regions/5
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
                return BadRequest($"Region {id} was found but failed to delete");
            }
        }
        // Patch api/ Regions/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> PatchRegion(int id, [FromBody] Region Region)
        {
            
            if (Region == null  || Region.RegionId != id)
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
            await _repo.PatchAsync(Region);
            return new NoContentResult();

        }
    }
}