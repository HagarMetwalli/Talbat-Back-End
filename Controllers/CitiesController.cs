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
    public class CitiesController : GenericController<City>
    {
        private IGenericService<City> repo;
        public CitiesController(IGenericService<City> repo) : base(repo)
        {
            this.repo = repo;
        }

        // Patch api/Cities/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> update(int id, [FromBody] City c)
        {
            if (c == null || c.CityId != id)
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
            await repo.UpdateAsync(id, c);
            return new NoContentResult();

        }

    }
}
