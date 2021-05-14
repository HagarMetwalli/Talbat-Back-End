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
    public class JobCategoryController : GenericController<JobCategory>
    {
        private IGenericService<JobCategory> repo_JobCategory;
       
        public JobCategoryController(IGenericService<JobCategory> repo_JobCategory) : base(repo_JobCategory)
        {
            this.repo_JobCategory = repo_JobCategory;
        }

        // Patch api/JobCategory/1
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Update(int id, [FromBody] JobCategory o)
        {
            if (o == null || o.JobCategoryId != id)
            {
                return BadRequest();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var JobCategory_Exist = await repo_JobCategory.RetriveAsync(id);


            if(JobCategory_Exist == null)
            {
                return NotFound();
            }

            await repo_JobCategory.UpdateAsync(o);
            return new NoContentResult();

        }
    }
}
