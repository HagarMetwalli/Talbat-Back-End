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
    public class SubItemCategoriesController : ControllerBase
    {
        private IGeneric<SubItemCategory> _repo;

        public SubItemCategoriesController(IGeneric<SubItemCategory> repo)
        {
            _repo = repo;
        }

        // GET: api/SubItemCategories
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<SubItemCategory>>))]
        public async Task<ActionResult<List<SubItemCategory>>> Get()
        {
            List<SubItemCategory> subItemCategories =await _repo.RetriveAllAsync();
            if (subItemCategories == null)
                return BadRequest();
            if (subItemCategories.Count == 0)
                return NoContent();
            return Ok(subItemCategories);
        }

        // GET api/SubItemCategories/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();
            SubItemCategory SubItemCategory = await _repo.RetriveAsync(id);
            if (SubItemCategory == null)
                return NotFound();
            return Ok(SubItemCategory);
        }

        // POST api/SubItemCategories
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] SubItemCategory SubItemCategory)
        {
            if (SubItemCategory == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            SubItemCategory added = await _repo.CreatAsync(SubItemCategory);
            if (added == null)
                return BadRequest();

            return Ok();
        }

        //Patch api/SubItemCategories/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SubItemCategory>> PatchSubItemCategory(int id, [FromBody] SubItemCategory SubItemCategory)
        {
            if (SubItemCategory == null || SubItemCategory.SubItemCategoryId != id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            var _client = await _repo.PatchAsync(SubItemCategory);
            if (_client == null)
                return BadRequest();

            return new NoContentResult();
        }
        // DELETE api/SubItemCategories/5
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
                return new NoContentResult();//204 No Content
            }
            else
            {
                return BadRequest($"SubItemCategory {id} was found but failed to delete");
            }
        }
    }
}