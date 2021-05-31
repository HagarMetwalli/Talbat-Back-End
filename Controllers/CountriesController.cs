using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private IGeneric<Country> _repo;
        public CountriesController(IGeneric<Country> repo)
        {
            _repo = repo;
        }

        // GET: api/countries
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Country>>))]
        public async Task<ActionResult<List<Country>>> Get()
        {
            List<Country> countries = await _repo.RetriveAllAsync();
            if (countries.Count == 0)
            {
                return NoContent();
            }
            if (countries == null)
            {
                return BadRequest();
            }
            return Ok(countries);
        }

        // GET api/countries/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            if(id <= 0)
            {
                return null;
            }
            Country country = await _repo.RetriveAsync(id);

            if (country == null)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST api/countries
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Country country)
        {
            if (country == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Country added = await _repo.CreatAsync(country);

            if (added == null)
            {
                return BadRequest();
            }

            return Ok(country);
        }

        // Patch api/countries/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Patch(int id, [FromBody] Country country)
        {
            if (id <= 0 || country == null || country.CountryId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existing = await _repo.RetriveAsync(country.CountryId);

            if (existing == null)
            {
                return NotFound();
            }
            await _repo.PatchAsync(country);
            return new NoContentResult();

        }
        // DELETE api/countries/5
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
                return BadRequest($"country {id} was found but failed to delete");
            }
        }

    }

}

