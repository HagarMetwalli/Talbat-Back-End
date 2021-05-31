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
        private IGenericService<SubItem> _repo;
        private TalabatContext _db;

        public SubItemsController(IGenericService<SubItem> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/SubItems
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<IList<SubItem>>))]
        public async Task<ActionResult<IList<SubItem>>> Get()
        {
            IList<SubItem> subItems = await _repo.RetriveAllAsync();
            if (subItems.Count == 0)
                return NoContent();
            return Ok(subItems);
        }

        // GET api/SubItems/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
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
            var SubItemCategory = _db.SubItemCategories.Find(SubItem.SubItemCategoryId);
            var Item = _db.Items.Find(SubItem.ItemId);

            if (SubItem == null || SubItemCategory == null || Item == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
                return BadRequest($"SubItem {id} was found but failed to delete");
            }
        }
        // Patch api/ SubItems/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> PatchSubItem(int id, [FromBody] SubItem SubItem)
        {
            var SubItemCategory = _db.SubItemCategories.Find(SubItem.SubItemCategoryId);
            var Item = _db.Items.Find(SubItem.ItemId);
            if (SubItem == null || SubItemCategory == null || Item == null || SubItem.SubItemId != id)
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
            await _repo.UpdateAsync(SubItem);
            return new NoContentResult();

        }
    }
}