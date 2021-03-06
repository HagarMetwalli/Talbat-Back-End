
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
        private Icity _repo;
        public CitiesController(Icity repo)
        {
            _repo = repo;
        }

        // GET: api/cities
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<City>>))]
        public async Task<ActionResult<List<City>>> Get()
        {
            List <City> cities = await _repo.RetriveAllAsync();
            if (cities.Count == 0)
            {
                return NoContent();
            }
            if(cities==null)
            {
                return BadRequest();
            }
            return Ok(cities);
        }
           

        // GET api/cities/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            City city = await _repo.RetriveAsync(id);

            if (city == null)
            {
                return NotFound();
            } 
            return Ok(city);
        }

        // POST api/cities
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] City city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            City added = await _repo.CreatAsync(city);

            if (added == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        //Patch api/cities/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<City>> Patch(int id, [FromBody] City city)
        {
            if (id <= 0 ||city == null || city.CityId != id)
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

            var c = await _repo.PatchAsync(city);
            if (c == null)
            {
                return BadRequest();
            }

            return new NoContentResult();
        }

        // DELETE api/cities/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return null;
            }
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
                return BadRequest($"City {id} was found but failed to delete");
            }
        }
    }
}
