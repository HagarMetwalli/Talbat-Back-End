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
    public class CuisinesController : ControllerBase
    {
        private ICuisienSevice _repo;
        private TalabatContext _db;

        public CuisinesController(ICuisienSevice repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/Cuisines
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cuisine>))]
        public async Task<IEnumerable<Cuisine>> Get() => await _repo.RetriveAllAsync();

        // GET api/Cuisines/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            Cuisine cuisine = await _repo.RetriveAsync(id);
            if (cuisine == null)
                return NotFound();
            return Ok(cuisine);
        }
        // GET api/Cuisines/Chine
        [HttpGet]
        [Route("GetByName/{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetByName(string name)
        {
            Cuisine cuisine = await _repo.RetriveByNameAsync(name);
            if (cuisine == null)
                return NotFound();
            return Ok(cuisine);
        }


        //// GET: api/Cuisines/MostCommonCuisine
        [HttpGet]
        [Route("MostCommonCuisine")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<String>))]
        public async Task<IEnumerable<object>> MostCommonCuisine()
        {

            return await _repo.RetriveMostCommonAsync();
        }

        // POST api/Cuisines
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Cuisine cuisine)
        {
            if (cuisine == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Cuisine added = await _repo.CreatAsync(cuisine);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/Cuisines/5
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
                return BadRequest($"Cuisine {id} was found but failed to delete");
            }
        }
        // Patch api/ Cuisines/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Patch(int id, [FromBody] Cuisine cuisine)
        {
            if (cuisine == null )
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
            await _repo.UpdateAsync(cuisine);
            return new NoContentResult();

        }
    }
}
