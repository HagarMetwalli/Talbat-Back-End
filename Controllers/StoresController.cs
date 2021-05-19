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
    public class StoresController : ControllerBase
    {
        private IStoreService _repo;
        private TalabatContext _db;

        public StoresController(IStoreService repo , TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/Stores
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Store>))]
        public async Task<IEnumerable<Store>> Get() => await _repo.RetriveAllAsync();

        // GET api/Stores/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            Store Store = await _repo.RetriveAsync(id);
            if (Store == null)
                return NotFound();
            return Ok(Store);
        }
        // GET: api/MostCommonStores
        [HttpGet]
        [Route("MostCommonStores")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Store>))]
        public async Task<IEnumerable<String>> MostCommonStores()
        {

            return await _repo.RetriveMostCommonStoreAsync();
        }
        //// GET: api/RetriveMostCommonCuisine
        [HttpGet]
        [Route("RetriveMostCommonCuisine")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<object>))]
        public async Task<IEnumerable<object>> MostCommonCuisine()
        {

            return await _repo.RetriveMostCommonCuisineAsync();
        }

        // POST api/Stores
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Store Store)
        {
            var CountryId = _db.Cities.Find(Store.CountryId);
            var StoreTypeId = _db.StoreTypes.Find(Store.StoreTypeId);

            if (Store == null || CountryId == null || StoreTypeId == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Store added = await _repo.CreatAsync(Store);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/Stores/5
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
                return BadRequest($"Store {id} was found but failed to delete");
            }
        }
        // Patch api/ Stores/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Patch(int id, [FromBody] Store Store)
        {
            var CountryId = _db.Cities.Find(Store.CountryId);
            var StoreTypeId = _db.StoreTypes.Find(Store.StoreTypeId);
            if (Store == null || CountryId == null || StoreTypeId == null || Store.StoreId != id)
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
            await _repo.UpdateAsync(Store);
            return new NoContentResult();

        }  
    }
}
