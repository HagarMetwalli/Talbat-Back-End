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
    public class ItemCategoriesController : ControllerBase
    {
        private IGenericService<ItemCategory> _repo;
        public ItemCategoriesController(IGenericService<ItemCategory> repo) 
        {
            _repo = repo;
        }
        // GET: api/itemcategories
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ItemCategory>))]
        public async Task<IEnumerable<ItemCategory>> Get() => await _repo.RetriveAllAsync();

        // GET api/ItemCategories/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            ItemCategory itemCategory = await _repo.RetriveAsync(id);
            if (itemCategory == null)
                return NotFound();
            return Ok(itemCategory);
        }

        // POST api/ItemCategories
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] ItemCategory itemCategory)
        {
            if (itemCategory == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ItemCategory added = await _repo.CreatAsync(itemCategory);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/ItemCategories/5
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
                return BadRequest($"itemcategory {id} was found but failed to delete");
            }
        }
    // Patch api/ItemCategories/5
    [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> PatchItemCategory(int id, [FromBody] ItemCategory i)
        {
            if (i == null || i.ItemCategoryId != id)
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
            await _repo.UpdateAsync(i);
            return new NoContentResult();

        }

    }
}