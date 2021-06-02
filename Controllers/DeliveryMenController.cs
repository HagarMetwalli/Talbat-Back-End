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
    public class DeliveryMenController : ControllerBase
    {
        private IGeneric<DeliveryMan> _repo;
        public DeliveryMenController(IGeneric<DeliveryMan> repo) 
        {
            _repo = repo;
        }
        // GET: api/DeliveryMen
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<DeliveryMan>>))]
        public async Task<ActionResult<List<DeliveryMan>>> Get()
        {
            List<DeliveryMan> deliveryMen = await _repo.RetriveAllAsync();
            if (deliveryMen.Count == 0)
            {
                return NoContent();
            }
            if(deliveryMen == null)
            {
                return BadRequest();
            }
            return Ok(deliveryMen);
        }

        // GET api/DeliveryMen/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            DeliveryMan deliveryMan = await _repo.RetriveAsync(id);
            if (deliveryMan == null)
            {
                return NotFound();
            }
            return Ok(deliveryMan);
        }

        // POST api/DeliveryMen
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] DeliveryMan deliveryMan)
        {
            if (deliveryMan == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DeliveryMan added = await _repo.CreatAsync(deliveryMan);
            if (added == null)
            {
                return BadRequest();
            }

            return Ok();
        }


        // Patch api/deliveryMen/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Patch(int id, [FromBody] DeliveryMan deliveryMan)
        {
            if (deliveryMan == null || deliveryMan.DeliveryManId != id)
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
            await _repo.PatchAsync(deliveryMan);
            return new NoContentResult();

        }
        // DELETE api/DeliveryMen/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
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
                return BadRequest($"DeliveryMan {id} was found but failed to delete");
            }
        }
    }
}
