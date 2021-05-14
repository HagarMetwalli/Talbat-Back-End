using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : GenericController<Client>
    {
        private IGenericService<Client> repo;

        public ClientsController(IGenericService<Client> repo) : base(repo)
        {
            this.repo = repo;
        }

        // Patch api/<GenericController>/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> update(int id, [FromBody] Client c)
        {
            if (c == null || c.ClientId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existing = await repo.RetriveAsync(c.ClientId);
            if (existing == null)
            {
                return NotFound();
            }
            await repo.UpdateAsync(c);
            return new NoContentResult();

        }
    }
}
