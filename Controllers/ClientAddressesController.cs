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
    public class ClientAddressesController : ControllerBase
    {
        private IGenericService<ClientAddress> _repo;
        public ClientAddressesController(IGenericService<ClientAddress> repo)
        {
            _repo = repo;
        }
        // GET: api/clientaddresses
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ClientAddress>))]
        public async Task<IEnumerable<ClientAddress>> Get() => await _repo.RetriveAllAsync();

        // GET api/clientaddresses/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            ClientAddress clientAddress = await _repo.RetriveAsync(id);
            if (clientAddress == null)
                return NotFound();
            return Ok(clientAddress);
        }

        // POST api/clientaddresses
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] ClientAddress clientAddress)
        {
            if (clientAddress == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ClientAddress added = await _repo.CreatAsync(clientAddress);
            if (added == null)
                return BadRequest();

            return Ok();
        }

        //Patch api/ClientAdrdresses/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ClientAddress>> PatchClientAddress(int id, [FromBody] ClientAddress clientAddress)
        {
            if (clientAddress == null || clientAddress.ClientAddressId!=id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            var c = await _repo.UpdateAsync(clientAddress);
            if (c == null)
                return BadRequest();

            return new NoContentResult();
        }
        // DELETE api/clientaddresses/5
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
                return BadRequest($"clientaddress {id} was found but failed to delete");
            }
        }
    }
}
