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
    public class StoresController : GenericController<Store>
    {
        private IGenericService<Store> repo_Store;
        
        public StoresController(IGenericService<Store> repo_Store) : base(repo_Store)
        {
            this.repo_Store = repo_Store;
        }

        // Patch api/Store/1
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Update(int id, [FromBody] Store o)
        {
            if (o == null || o.StoreId != id)
            {
                return BadRequest();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Job_Exist = await repo_Store.RetriveAsync(id);
        
            if (Job_Exist == null)
            {
                return NotFound();
            }

            await repo_Store.UpdateAsync(id, o);
            return new NoContentResult();

        }
    }
}
