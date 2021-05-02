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
    public class OfferController : GenericController<Offer>
    {
        private IGenericService<Offer> repo_Offer;
       
        public OfferController(IGenericService<Offer> repo_Offer) : base(repo_Offer)
        {
            this.repo_Offer = repo_Offer;
        }

        // Patch api/Offer/1
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Update(int id, [FromBody] Offer o)
        {
            if (o == null || o.OfferId != id)
            {
                return BadRequest();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Offer_Exist = await repo_Offer.RetriveAsync(id);

            

            if (Offer_Exist == null)
            {
                return NotFound();
            }

            await repo_Offer.UpdateAsync(id, o);
            return new NoContentResult();

        }
    }
}
