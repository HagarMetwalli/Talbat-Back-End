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
    public class DeliveryMenController : GenericController<DeliveryMan>
    {
        private IGenericService<DeliveryMan> repo;
        public DeliveryMenController(IGenericService<DeliveryMan> repo) : base(repo)
        {
            this.repo = repo;
        }
        // Patch api/deliveryMen/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> update(int id, [FromBody] DeliveryMan d)
        {
            if (d == null || d.DeliveryManId != id)
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
            await repo.UpdateAsync( d);
            return new NoContentResult();

        }

    }
}
