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
    public class ClientAdrdressesController : GenericController<ClientAddress>
    {
        private IGenericService<ClientAddress> repo;
        public ClientAdrdressesController(IGenericService<ClientAddress> repo) : base(repo)
        {
            this.repo = repo;
        }
        // Patch api/ClientAddresses/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> update(int id, [FromBody] ClientAddress c)
        {
            if (c == null || c.ClientAddressId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existing = await repo.RetriveAsync(c.ClientAddressId);
            if (existing == null)
            {
                return NotFound();
            }
            await repo.UpdateAsync(c);
            return new NoContentResult();

        }
    }
}
