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
    public class SubItemsController : ControllerBase
    {
        private IGeneric<SubItem> _repo;
        private TalabatContext _db;

        public SubItemsController(IGeneric<SubItem> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/SubItems
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<SubItem>>))]
        public async Task<ActionResult<List<SubItem>>> Get()
        {
            List<SubItem> subItems = await _repo.RetriveAllAsync();
            if (subItems == null)
                return BadRequest();
            if (subItems.Count == 0)
                return NoContent();
            return Ok(subItems);
        }

        // GET api/SubItems/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]


        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();
            SubItem SubItem = await _repo.RetriveAsync(id);
            if (SubItem == null)
                return NotFound();
            return Ok(SubItem);
        }

        // POST api/SubItems
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] SubItem SubItem)
        {
            if (SubItem == null )
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var SubItemCategory = _db.SubItemCategories.Find(SubItem.SubItemCategoryId);
            var Item = _db.Items.Find(SubItem.ItemId);

            if (SubItemCategory == null || Item == null)
                return BadRequest();

            SubItem added = await _repo.CreatAsync(SubItem);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/SubItems/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();
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
                return BadRequest($"SubItem {id} was found but failed to delete");
            }
        }
        // Patch api/ SubItems/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Patch(int id, [FromBody] SubItem SubItem)
        {
            if (SubItem == null || SubItem.SubItemId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var SubItemCategory = _db.SubItemCategories.Find(SubItem.SubItemCategoryId);
            var Item = _db.Items.Find(SubItem.ItemId);
            if (SubItemCategory == null || Item == null)
            {
                return BadRequest();
            }
    
            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            var effected= await _repo.PatchAsync(SubItem);
            if (effected == null)
                return null;
            return new NoContentResult();

        }
    }
}