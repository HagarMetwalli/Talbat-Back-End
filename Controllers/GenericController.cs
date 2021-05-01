using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Talbat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController <T> : Controller where T :class
    {
        private IGenericService<T> repo;
        public GenericController(IGenericService<T> repo)
        {
            this.repo = repo;
        }
        // GET: api/<GenericController>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<>))]
        public async Task<IEnumerable<T>> Get() => await repo.RetriveAllAsync();

        // POST api/<GenericController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] T item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            T added = await repo.CreatAsync(item);
            return Ok(item);
        }
        // GET api/<GenericController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            T item = await repo.RetriveAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        // DELETE api/<GenericController>/5
        [HttpDelete("{id}")]
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            bool? deleted = await repo.DeleteAsync(id);
            if (deleted.HasValue && deleted.Value)
            {
                return new NoContentResult();//204 No Content
            }
            else
            {
                return BadRequest($"item {id} was found but failed to delete");
            }
        }
    }
}
