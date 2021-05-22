
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IGenericService<City> _repo;
        public CitiesController(IGenericService<City> repo)
        {
            _repo = repo;
        }
        // GET: api/cities
        [HttpGet]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<IList<City>>))]
        public async Task<ActionResult<IList<City>>> Get()
        {
            IList <City> citires = await _repo.RetriveAllAsync();
            if (citires.Count == 0)
                return NoContent();
            return Ok(citires);
        }
           

        // GET api/cities/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            City city = await _repo.RetriveAsync(id);
            if (city == null)
                return NotFound();
            return Ok(city);
        }

        // POST api/cities
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] City city)
        {
            if (city == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            City added = await _repo.CreatAsync(city);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        //Patch api/cities/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<City>> PatchCity(int id, [FromBody] City city)
        {
            if (city == null || city.CityId != id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            var c = await _repo.UpdateAsync(city);
            if (c == null)
                return BadRequest();

            return new NoContentResult();
        }
        // DELETE api/cities/5
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
                return BadRequest($"city {id} was found but failed to delete");
            }
        }
    }
}
