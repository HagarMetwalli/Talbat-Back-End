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
    public class ClientsPromotionsController : ControllerBase
    {
        private IGenericService<ClientPromotion> _repo;
        public ClientsPromotionsController(IGenericService<ClientPromotion> repo) 
        {
            _repo = repo;
        }
        // GET: api/ClientPromotions
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<IList<ClientPromotion>>))]
        public async Task<ActionResult<IList<Client>>> Get()
        {
            IList<ClientPromotion> clientPromotions = await _repo.RetriveAllAsync();
            if (clientPromotions.Count == 0)
                return NoContent();
            return Ok(clientPromotions);
        }

        // GET api/ClientPromotions/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            ClientPromotion clientPromotion = await _repo.RetriveAsync(id);
            if (clientPromotion == null)
                return NotFound();
            return Ok(clientPromotion);
        }

        // POST api/ClientPromotions
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] ClientPromotion clientPromotion)
        {
            if (clientPromotion == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ClientPromotion added = await _repo.CreatAsync(clientPromotion);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        //Patch api/ClientPromotions/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<City>> PatchClientPromotion(int id, [FromBody] ClientPromotion clientPromotion)
        {
            if (clientPromotion == null || clientPromotion.PromotionId != id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            var _clientPromotion = await _repo.UpdateAsync(clientPromotion);
            if (_clientPromotion == null)
                return BadRequest();

            return new NoContentResult();
        }
        // DELETE api/ClientPromotions/5
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
                return BadRequest($"ClientsPromotions {id} was found but failed to delete");
            }
        }
    }
}
