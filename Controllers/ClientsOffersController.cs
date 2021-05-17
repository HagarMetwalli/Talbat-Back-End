using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Controllers
{
    public class ClientsOffersController : ControllerBase
    {
        private IGenericService<ClientOffer> repo;
        public ClientsOffersController(IGenericService<ClientOffer> repo) 
        {
            this.repo = repo;
        }
        // Patch api/ClientsOffers/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> update(int id, [FromBody] ClientOffer c)
        {
            if (c == null || c.UserId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existing = await repo.RetriveAsync(c.UserId);
            if (existing == null)
            {
                return NotFound();
            }
            await repo.UpdateAsync(c);
            return new NoContentResult();

        }
    }
}
