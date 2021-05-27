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
    public class AddressTypesController : ControllerBase
    {
        private IGenericService<AddressType> _repo;
        public AddressTypesController(IGenericService<AddressType> repo)
        {
            _repo = repo;
        }
        // GET: api/addresstypes
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<IList<AddressType>>))]
        public async Task<ActionResult<IList<City>>> Get()
        {
            IList<AddressType> addressTypes = await _repo.RetriveAllAsync();
            if (addressTypes.Count == 0)
                return NoContent();
            return Ok(addressTypes);
        }

        // GET api/addresstypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            AddressType addressType = await _repo.RetriveAsync(id);
            if (addressType == null)
                return NotFound();
            return Ok(addressType);
        }

        // POST api/addresstypes
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] AddressType addressType)
        {
            if (addressType == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AddressType added = await _repo.CreatAsync(addressType);
            if (added == null)
                return BadRequest();

            return Ok(addressType);
        }

        //Patch api/addresstypes/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<AddressType>> PatchAddressType(int id, [FromBody] AddressType addressType)
        {
            if (addressType == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            var _addressType = await _repo.UpdateAsync(addressType);
            if (_addressType == null)
                return BadRequest();

            return new NoContentResult();
        }
        // DELETE api/addresstypes/5
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
                return BadRequest($"AddressType {id} was found but failed to delete");
            }
        }

    }
}
