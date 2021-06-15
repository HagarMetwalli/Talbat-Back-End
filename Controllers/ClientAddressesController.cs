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
        private IClientAddressesRelated _repo;
        private TalabatContext _db;

        public ClientAddressesController(IClientAddressesRelated repo,TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }

        // GET: api/clientaddresses
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<ClientAddress>>))]
        public async Task<ActionResult<List<City>>> Get()
        {
            List<ClientAddress> clientAddresses = await _repo.RetriveAllAsync();
            if (clientAddresses.Count == 0)
            {
                return NoContent();
            }

            if(clientAddresses == null)
            {
                return BadRequest();
            }
            return Ok(clientAddresses);
        }

        // GET api/clientaddresses/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            ClientAddress clientAddress = await _repo.RetriveAsync(id);
            if (clientAddress == null)
            {
                return NotFound();
            }
            return Ok(clientAddress);
        }

        // GET api/GetByClientId/5
        [HttpGet("GetByClientId/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult GetByClientId(int id)
        {
            var clientAddresses = _repo.RetriveByClientIdAsync(id);
            if (clientAddresses.Count == 0)
            {
                return NotFound();
            }
            return Ok(clientAddresses);
        }

        // POST api/clientaddresses
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] ClientAddress clientAddress)
        {

            if (clientAddress == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientId = _db.Clients.Find(clientAddress.ClientId);
            var addresstypeId = _db.AddressTypes.Find(clientAddress.ClientAddressTypeId);
            var cityId = _db.Cities.Find(clientAddress.CityId);
            var regionId = _db.Regions.Find(clientAddress.RegionId);

            if (clientId == null || addresstypeId == null || cityId == null || regionId == null)
            {
                return BadRequest();
            }

            ClientAddress added = await _repo.CreatAsync(clientAddress);

            if (added == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        //Patch api/ClientAdrdresses/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ClientAddress>> Patch(int id, [FromBody] ClientAddress clientAddress)
        {
            if (id <= 0 || clientAddress == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientId = _db.Clients.Find(clientAddress.ClientId);
            var addresstypeId = _db.AddressTypes.Find(clientAddress.ClientAddressTypeId);
            var cityId = _db.Cities.Find(clientAddress.CityId);
            var regionId = _db.Regions.Find(clientAddress.RegionId);

            if (clientId == null || addresstypeId == null || cityId == null || regionId == null)
            {
                return BadRequest();
            }

            var existing = await _repo.RetriveAsync(id);

            if (existing == null)
            {
                return NotFound();
            }
            var c = await _repo.PatchAsync(clientAddress);

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

            bool deleted = await _repo.DeleteAsync(id);

            if (deleted)
            {
                return new NoContentResult();
            }

            else
            {
                return BadRequest($"clientaddress {id} was found but failed to delete");
            }
        }
    }
}
