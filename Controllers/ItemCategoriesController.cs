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
        private IItemCategoryService _repo;
        public ItemCategoriesController(IItemCategoryService repo) 
        {
            _repo = repo;
        }
        // GET: api/itemcategories
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<ItemCategory>>))]
        public async Task<ActionResult<List<ItemCategory>>> Get()
        {
            List<ItemCategory> itemCategories = await _repo.RetriveAllAsync();
            if (itemCategories.Count == 0)
            {
                return NoContent();
            }
            if (itemCategories == null)
            {
                return BadRequest();
            }
            return Ok(itemCategories);
        }

        // GET api/ItemCategories/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            ItemCategory itemCategory = await _repo.RetriveAsync(id);
            if (itemCategory == null)
            {
                return NotFound();
            }
            return Ok(itemCategory);
        }
        // GET api/ItemCategories/Name
        [HttpGet]
        [Route("GetByName/{itemCategory}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetByName(string itemCategory)
        {
            ItemCategory _itemCategory = await _repo.RetriveByNameAsync(itemCategory);
            if (_itemCategory == null)
            {
                return NotFound();
            }
            return Ok(_itemCategory);
        }

        // POST api/ItemCategories
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] ItemCategory itemCategory)
        {
            if (itemCategory == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ItemCategory added = await _repo.CreatAsync(itemCategory);
            if (added == null)
            {
                return BadRequest();
            }
            return Ok();
        }


    // Patch api/ItemCategories/5
    [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Patch(int id, [FromBody] ItemCategory itemCategory)
        {
            if (id<=0 ||itemCategory == null || itemCategory.ItemCategoryId != id)
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
            await _repo.PatchAsync(itemCategory);
            return new NoContentResult();

        }

        // DELETE api/ItemCategories/5
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
                return BadRequest($"itemcategory {id} was found but failed to delete");
            }
        }
    }
}