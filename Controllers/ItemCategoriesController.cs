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
    public class ItemCategoriesController : GenericController<ItemCategory>
    {
        private IGenericService<ItemCategory> repo;
        public ItemCategoriesController(IGenericService<ItemCategory> repo) : base(repo)
        {
            this.repo = repo;
        }
        // Patch api/Cities/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> update(int id, [FromBody] ItemCategory i)
        {
            if (i == null || i.ItemCategoryId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existing = await repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            await repo.UpdateAsync(id, i);
            return new NoContentResult();

        }

    }
}