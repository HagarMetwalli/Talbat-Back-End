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
    public class ItemsController : ControllerBase
    {
        private IGenericService<Item> _repo;
        private TalabatContext _db;

        public ItemsController(IGenericService<Item> repo,TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/items
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Item>))]
        public async Task<IEnumerable<Item>> Get() => await _repo.RetriveAllAsync();

        // GET api/items/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            Item item = await _repo.RetriveAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        // POST api/items
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Item item)
        {
            var countryId = _db.Countries.Find(item.CountryId);
            var storeId = _db.Stores.Find(item.StoreId);

            if (item == null || countryId==null || storeId ==null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Item added = await _repo.CreatAsync(item);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/items/5
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
                return BadRequest($"item {id} was found but failed to delete");
            }
        }

        // Patch api/Cities/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> PatchItem(int id, [FromBody] Item item)
        {
            var countryId = _db.Countries.Find(item.CountryId);
            var storeId = _db.Stores.Find(item.StoreId);
            if (item == null ||countryId==null|| storeId==null|| item.ItemId != id)
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
            await _repo.UpdateAsync(item);
            return new NoContentResult();

        }
    }
}
