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
    public class JobController : GenericController<Job>
    {
        private IGenericService<Job> repo_Job;
        
        public JobController(IGenericService<Job> repo_Job) : base(repo_Job)
        {
            this.repo_Job = repo_Job;
        }

        // Patch api/Job/1
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Update(int id, [FromBody] Job o)
        {
            if (o == null || o.JobId != id)
            {
                return BadRequest();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Job_Exist = await repo_Job.RetriveAsync(id);
        
            if (Job_Exist == null)
            {
                return NotFound();
            }

            await repo_Job.UpdateAsync( o);
            return new NoContentResult();

        }
    }
}
