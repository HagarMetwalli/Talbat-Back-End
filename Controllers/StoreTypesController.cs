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
    public class StoreTypesController : GenericController<StoreType>
    {
        private IGenericService<StoreType> repo_StoreType;
        
        public StoreTypesController(IGenericService<StoreType> repo_StoreType) : base(repo_StoreType)
        {
            this.repo_StoreType = repo_StoreType;
        }

        // Patch api/StoreType/1
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Update(int id, [FromBody] StoreType o)
        {
            if (o == null || o.StoreTypeId != id)
            {
                return BadRequest();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var StoreType_Exist = await repo_StoreType.RetriveAsync(id);
        
            if (StoreType_Exist == null)
            {
                return NotFound();
            }

            await repo_StoreType.UpdateAsync(id, o);
            return new NoContentResult();

        }
    }
}
