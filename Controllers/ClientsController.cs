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
    public class ClientsController : ControllerBase
    {
        private IGenericService<Client> _repo;

        public ClientsController(IGenericService<Client> repo)
        {
            _repo = repo;
        }

        // GET: api/clients
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Client>))]
        public async Task<IEnumerable<Client>> Get() => await _repo.RetriveAllAsync();

        // GET api/clients/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            Client client = await _repo.RetriveAsync(id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        // POST api/clients
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            if (client == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Client added = await _repo.CreatAsync(client);
            if (added == null)
                return BadRequest();

            return Ok();
        }

        //Patch api/clients/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<City>> PatchClient(int id, [FromBody] Client client)
        {
            if (client == null || client.ClientId!=id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            var _client = await _repo.UpdateAsync(client);
            if (_client == null)
                return BadRequest();

            return new NoContentResult();
        }
        // DELETE api/clients/5
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
                return BadRequest($"client {id} was found but failed to delete");
            }
        }
    }
}
