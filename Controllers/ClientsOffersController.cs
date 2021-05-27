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
    public class ClientsOffersController : ControllerBase
    {
        private IGenericService<ClientOffer> _repo;
        public ClientsOffersController(IGenericService<ClientOffer> repo) 
        {
            _repo = repo;
        }
        // GET: api/ClientsOffers
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<IList<ClientOffer>>))]
        public async Task<ActionResult<IList<Client>>> Get()
        {
            IList<ClientOffer> clientOffers = await _repo.RetriveAllAsync();
            if (clientOffers.Count == 0)
                return NoContent();
            return Ok(clientOffers);
        }

        // GET api/ClientsOffers/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            ClientOffer clientOffer = await _repo.RetriveAsync(id);
            if (clientOffer == null)
                return NotFound();
            return Ok(clientOffer);
        }

        // POST api/ClientsOffers
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] ClientOffer clientOffer)
        {
            if (clientOffer == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ClientOffer added = await _repo.CreatAsync(clientOffer);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        //Patch api/ClientsOffers/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<City>> PatchClientOffer(int id, [FromBody] ClientOffer clientOffer)
        {
            if (clientOffer == null || clientOffer.OfferId != id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            var _clientOffer = await _repo.UpdateAsync(clientOffer);
            if (_clientOffer == null)
                return BadRequest();

            return new NoContentResult();
        }
        // DELETE api/ClientsOffers/5
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
                return BadRequest($"ClientsOffers {id} was found but failed to delete");
            }
        }
    }
}
