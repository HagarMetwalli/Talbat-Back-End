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
    public class StoresController : ControllerBase
    {
        private IStoreService _repo;
        private TalabatContext _db;
        private IItemCategoryService _itemCategoryRepo;

        public StoresController(IStoreService repo, IItemCategoryService itemCategoryRepo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
            _itemCategoryRepo = itemCategoryRepo;
        }
        // GET: api/Stores
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Store>>))]
        public async Task<ActionResult<List<Store>>> Get()
        {
            List<Store> stores = await _repo.RetriveAllAsync();
            if (stores == null)
                return BadRequest();
            if (stores.Count == 0)
                return NoContent();
            return Ok(stores);
        }

        // GET api/Stores/5
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();
            Store Store = await _repo.RetriveAsync(id);
            if (Store == null)
                return NotFound();
            return Ok(Store);
        }
        // GET: api/stores/Getwithname
        [HttpGet]
        [Route("Getwithname/{storeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Item>>))]
        public async Task<ActionResult<List<Client>>> Getwithname(int storeId)
        {

            IList<Item> items = await _repo.RetriveAllWithNameAsync(storeId);
            if (items.Count == 0)
            {
                return NoContent();
            }
            if (items == null)
            {
                return BadRequest();
            }
            return Ok(items);
        }
        // GET api/Stores/5
        [HttpGet]
        [Route("GetTopItemsBystoreId/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetTopItemsBystoreId(int id)
        {
            if (id <= 0)
                return BadRequest();
            var items = await _repo.RetriveTopItemsAsync(id);
            if (items == null)
                return NotFound();
            return Ok(items);
        }
        // GET api/Stores/MC
        [HttpGet]
        [Route("GetByName/{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetByName(string name)
        {
            if (name == null)
                return BadRequest();
            Store Store = await _repo.RetriveByNameAsync(name);
            if (Store == null)
                return NotFound();
            return Ok(Store);
        }


        // GET api/Stores/MC/Categories
        [HttpGet]
        [Route("{StoreName}/Categories")]
        [ProducesResponseType(200, Type = typeof(List<string>))]
        public async Task<ActionResult<IEnumerable<string>>> StoreCateories(string StoreName)
        {

            Store store = await _repo.RetriveByNameAsync(StoreName);
            if (store == null)
                return NotFound();

            IEnumerable<string> CategoriesName = await _repo.RetriveCategoriesAsync(store.StoreId);
            if (CategoriesName == null)
                return NotFound();

            return Ok(CategoriesName);
        }

        // GET api/Stores/Menu
        [HttpGet]
        [Route("{StoreName}/Menu")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(List<Item>))]
        public async Task<ActionResult<IEnumerable<Item>>> StoreMenu(string StoreName)
        {
            Store store = await _repo.RetriveByNameAsync(StoreName);
            if (store == null)
                return NotFound();
            IEnumerable<Item> ItemsList = await _repo.RetriveMenuAsync(store.StoreId);
            if (ItemsList == null)
                return NotFound();
            return Ok(ItemsList);
        }

        // GET api/NearestStores
        [HttpGet]
        [Route("NearestStores/{latitude}/{Longitude}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(List<Store>))]
        public async Task<ActionResult<List<Store>>> NearestStores(double latitude, double Longitude)
        {
            List<Store> stores = await _repo.RetriveStoresBasedLocationAsync(latitude, Longitude);
            if (stores.Count == 0)
            {
                return NotFound();
            }
            if (stores == null)
            {
                return NotFound();
            }

            return Ok(stores);
        }

        // GET api/NearestStores
        [HttpGet]

        [Route("GetStoreInLocationAsync/{storeId}/{latitude}/{Longitude}")]
        [ProducesResponseType(200)]

        [ProducesResponseType(400)]
        [ProducesResponseType(404)] 


        public async Task<IActionResult> GetStoreInLocationAsync(int storeid,double latitude, double Longitude)
        {
            Store store =_db.Stores.Where(a =>a.StoreId == storeid).First();

            if (store == null)
            {
                return BadRequest();
            }

            try

            {
                var avaliablity = await _repo.RetriveStoreInLocationAsync(storeid, latitude, Longitude);
                if (avaliablity != null)
                {
                    return Ok(avaliablity);
                }
                return NotFound();
            }
            catch
            {
                return NotFound();
            }
           
        }
        // GET api/Stores/MC/Drinks
        [HttpGet]
        [Route("{StoreName}/{CategoryName}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(List<Item>))]
        public async Task<ActionResult<IEnumerable<Item>>> StoreMenuwithCategries(string StoreName, string CategoryName)
        {
            Store store = await _repo.RetriveByNameAsync(StoreName);
            ItemCategory itemCategory = await _itemCategoryRepo.RetriveByNameAsync(CategoryName);
            if (store == null || itemCategory == null)
                return NotFound();
            IEnumerable<Item> ItemsList = await _repo.RetriveCategoryItemsAsync(store.StoreId, itemCategory.ItemCategoryId);
            if (ItemsList == null)
                return NotFound();
            return Ok(ItemsList);
        }
        // GET: api/MostCommonStores
        [HttpGet]
        [Route("MostCommonStores")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Store>))]
        public async Task<ActionResult<IEnumerable<Item>>> MostCommonStores()
        {
            IEnumerable<String> list = await _repo.RetriveMostCommonAsync();
            if (list == null)
                return BadRequest();
            if (list.Count() == 0)
                return NoContent();
            return Ok(list);
        }

        // POST api/Stores
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Store store)
        {
            if (store == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var CountryId = _db.Countries.Find(store.CountryId);
            var StoreTypeId = _db.StoreTypes.Find(store.StoreTypeId);
            var CuisineId = _db.Cuisines.Find(store.CuisineId);
            if (CountryId == null || StoreTypeId == null || CuisineId == null)
            {
                return BadRequest();
            }

            Store added = await _repo.CreateStoreAsync(store);
            if (added == null)
            {
                return BadRequest();
            }
            return Ok(added);
        }

        // Patch api/ Stores/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Patch(int id, [FromForm] Store store, IFormFile storeImage)
        {
            if (store == null || store.StoreId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var CountryId = _db.Countries.Find(store.CountryId);
            var StoreTypeId = _db.StoreTypes.Find(store.StoreTypeId);
            var CuisineId = _db.Cuisines.Find(store.CuisineId);
            if (CountryId == null || StoreTypeId == null || CuisineId == null)
            {
                return BadRequest();
            }
            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            var affected = await _repo.PatchStoreAsync(store, storeImage);
            if (affected == null)
            {
                return BadRequest();
            }
            return new NoContentResult();

        }


        // DELETE api/Stores/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var existing = await _repo.RetriveAsync(id);

            if (existing == null)
                return NotFound();

            bool deleted = await _repo.DeleteAsync(id);
            if (deleted)
            {
                return new NoContentResult();
            }
            else
            {
                return BadRequest($"Store {id} was found but failed to delete");
            }
        }

 
        //// GET api/Stores/GetStoreInArea/area
        //[HttpGet]
        //[Route("GetStoreInArea/{area}")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]

        //public async Task<IActionResult> GetStorebyfilter(string area)
        //{
        //    if (area == null)
        //    {
        //        return BadRequest();
        //    }
        //    var stores = await _repo.RetriveStoreInAreaAsync(area);
        //    {

        //        if (stores.Count == 0)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(stores);
        //    }
        //}

        // GET api/Stores/GetStoresWithType/area
        [HttpGet]
        [Route("GetStoresWithType/{storeTypeId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetStoresWithType(string storeTypeId)
        {
            if (storeTypeId == null)
            {
                return BadRequest();
            }
            StoreType storeType = _db.StoreTypes.Find(storeTypeId);

            if (storeType == null)
            {
                return BadRequest();
            }
            var stores = await _repo.RetriveStoreWithTypeIdAsync(storeType.StoreTypeId);
            {

                if (stores.Count == 0)
                {
                    return NotFound();
                }
                return Ok(stores);
            }
        }
        // GET api/Stores/GetCategories
        [HttpGet]
        [Route("GetCategories/{storeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]

        public async Task<IActionResult> GetCategories(int storeId)
        {
            Store store = _db.Stores.Find(storeId);

            if (store == null)
            {
                return BadRequest();
            }
            var itemCategories = await _repo.RetriveItemCategoriesAsync(storeId);
            {
                if (itemCategories.Count == 0)
                {
                    return NotFound();
                }
                return Ok(itemCategories);
            }
        }
        // GET api/Stores/GetStoresWithCusineName/cusineId
        [HttpGet]
        [Route("GetStoresWithCusineName/{cusineId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetStoresWithCusineName(string cusineId)
        {
            if (cusineId == null)
            {
                return BadRequest();
            }
            Cuisine cuisine = _db.Cuisines.Find(cusineId);

            if (cuisine == null)
            {
                return BadRequest();
            }
            var stores = await _repo.RetriveStoreWithCuisineIdAsync(cuisine.CuisineId);
            {

                if (stores.Count == 0)
                {
                    return NotFound();
                }
                return Ok(stores);
            }
        }
    }
}
