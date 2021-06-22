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
        private IItemService _repo;
        private TalabatContext _db;

        public ItemsController(IItemService repo,TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/items
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Item>>))]
        public async Task<ActionResult<List<Client>>> Get()
        {
            IList<Item> items = await _repo.RetriveAllAsync();
            if (items.Count == 0)
            {
                return NoContent();
            }
            if(items == null)
            {
                return BadRequest();
            }
            return Ok(items);
        }

        // GET api/items/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            Item item = await _repo.RetriveAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // GET api/items/GetSubItemsByItemId/5
        [HttpGet]
        [Route("GetSubItemsByItemId/{itemId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetSubItemsByItemId(int itemId)
        {
            Item item = await _repo.RetriveAsync(itemId);
            if (item == null)
            {
                return NotFound();
            }
            var subItems = await _repo.RetriveSubItemsByItemIdAsync(itemId);
            return Ok(item);
        }

        //GET api/items/GetSubItemsCategoriesByItemId/5
        [HttpGet]
        [Route("GetSubItemsCategoriesByItemId/{itemId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSubItemsCategoriesByItemId(int itemId)
        {
            Item item = await _repo.RetriveAsync(itemId);
            if (item == null)
            {
                return NotFound();
            }
            var subItems = await _repo.RetriveSubItemsCategoriesByItemIdAsync(itemId);
            return Ok(subItems);
        }

        // POST api/items
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Item item)
        {

            if (item == null )
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var countryId = _db.Countries.Find(item.CountryId);
            var storeId = _db.Stores.Find(item.StoreId);

            if (countryId == null || storeId == null)
            {
                return BadRequest();
            }

            Item added = await _repo.CreatAsync(item);
            if (added == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE api/items/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var existing = await _repo.RetriveAsync(id);

            if (existing == null)
            {
                return NotFound();
            }
            bool deleted = await _repo.DeleteAsync(id);

            if (deleted)
            {
                return new NoContentResult();
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

        public async Task<IActionResult> Patch(int id, [FromBody] Item item)
        {
            if (id <=0 || item == null ||item.ItemId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var countryId = _db.Countries.Find(item.CountryId);
            var storeId = _db.Stores.Find(item.StoreId);

            if (countryId == null || storeId == null )
            {
                return BadRequest();
            }
            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            await _repo.PatchAsync(item);
            return new NoContentResult();

        }
    }
}
