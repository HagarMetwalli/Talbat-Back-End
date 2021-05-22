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
    public class StoreTypesController : ControllerBase
    {
        private IGenericService<StoreType> _repo;
        private TalabatContext _db;

        public StoreTypesController(IGenericService<StoreType> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/StoreTypes
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<IList<StoreType>>))]
        public async Task<ActionResult<IList<StoreType>>> Get()
        {
            IList<StoreType> storeTypes = await _repo.RetriveAllAsync();
            if (storeTypes == null)
                return NotFound();
            return Ok(storeTypes);
        }

        // GET api/StoreTypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            StoreType StoreType = await _repo.RetriveAsync(id);
            if (StoreType == null)
                return NotFound();
            return Ok(StoreType);
        }

        // POST api/StoreTypes
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] StoreType StoreType)
        {
            

            if (StoreType == null )
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StoreType added = await _repo.CreatAsync(StoreType);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/StoreTypes/5
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
                return BadRequest($"StoreType {id} was found but failed to delete");
            }
        }
        // Patch api/StoreTypes/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Patch(int id, [FromBody] StoreType StoreType)
        {
          
            if (StoreType == null || StoreType.StoreTypeId != id)
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
            await _repo.UpdateAsync(StoreType);
            return new NoContentResult();

        }
    }
}