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
    public class PartnersController : ControllerBase
    {
        private IGenericService<Partner> _repo;
        private TalabatContext _db;

        public PartnersController(IGenericService<Partner> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/Partners
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<IList<Partner>>))]
        public async Task<ActionResult<IList<Client>>> Get()
        {
            IList<Partner> partners = await _repo.RetriveAllAsync();
            if (partners.Count == 0)
                return NoContent();
            return Ok(partners);
        }

        // GET api/Partners/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            Partner Partner = await _repo.RetriveAsync(id);
            if (Partner == null)
                return NotFound();
            return Ok(Partner);
        }

        // POST api/Partners
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Partner Partner)
        {
            var StoreId = _db.Stores.Find(Partner.StoreId);

            if (Partner == null || StoreId == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Partner added = await _repo.CreatAsync(Partner);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/Partners/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            bool? deleted = await _repo.DeleteAsync(id);
            if (deleted.HasValue && deleted.Value)
            {
                return new NoContentResult();//204 No Content
            }
            else
            {
                return BadRequest($"Partner {id} was found but failed to delete");
            }
        }
        // Patch api/ Partners/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> PatchPartner(int id, [FromBody] Partner Partner)
        {
            var StoreId = _db.Stores.Find(Partner.StoreId);
            if (Partner == null || StoreId == null || Partner.PartnerId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            await _repo.UpdateAsync(Partner);
            return new NoContentResult();

        }
    }
}
