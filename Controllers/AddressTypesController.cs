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
        private IAddressType _repo;
        public AddressTypesController(IAddressType repo)
        {
            _repo = repo;
        }
        //// GET: api/addresstypes
        //[HttpGet]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(200, Type = typeof(ActionResult<List<AddressType>>))]
        //public async Task<ActionResult<IList<City>>> Get()
        //{
        //    List<AddressType> addressTypes = await _repo.RetriveAllAsync();
        //    if (addressTypes.Count == 0)
        //        return NoContent();
        //    return Ok(addressTypes);
        //}

        //// GET api/addresstypes/5
        //[HttpGet("{id}")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest();
        //    }
        //    AddressType addressType = await _repo.RetriveAsync(id);
        //    if (addressType == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(addressType);
        //}

        // POST api/addresstypes
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] AddressType addressType)
        {
            if (addressType == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                
            AddressType added = await _repo.CreatAsync(addressType);
            if (added == null)
            {
                return BadRequest();
            }

            return Ok(addressType);
        }

        //Patch api/addresstypes/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<AddressType>> Patch(int id, [FromBody] AddressType addressType)
        {
            if (addressType == null)
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
            var _addressType = await _repo.PatchAsync(addressType);

            if (_addressType == null)
            {
                return BadRequest();
            }
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

            bool deleted = await _repo.DeleteAsync(id);

            if (deleted)
            {
                return new NoContentResult();
            }
            else
            {
                return BadRequest($"AddressType {id} was found but failed to delete");
            }
        }

    }
}
