using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class StoreService :IStoreService
    {
        private TalabatContext _db;
        public StoreService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Store> CreatAsync(Store Store)
        {
            try {
                await _db.Stores.AddAsync(Store);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return Store;
                return null; 
            }
            catch {
                return null;
            }
        }
       
        public async Task<bool> DeleteAsync(int id)
        {
            try {

            Store Store = await RetriveAsync(id);
            _db.Stores.Remove(Store);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return false;
            }
            catch
            {
                return false;
            }
        }
      
        public Task<List<Store>> RetriveAllAsync()
        {
            try
            {
                return Task<List<Store>>.Run<List<Store>>(() => _db.Stores.ToList());
            }
            catch
            {
                return null;
            }
        }
        public Task<Store> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.Stores.Find(id));
            }
            catch
            {
                return null;
            }

        }

        public Task<IEnumerable<String>> RetriveMostCommonAsync()
        {
            try { 
            var stores = _db.Stores.OrderByDescending(s => s.StoreOrdersNumber).Take(5).Select(s=>s.StoreName).ToList();
            return Task<IEnumerable>.Run<IEnumerable<String>>(() => stores);
            }
            catch
            {
                return null;
            }
        }
        public Task<Store> RetriveByNameAsync(string storename)
        {
            try { 
            var store = _db.Stores.FirstOrDefault(s=>s.StoreName==storename);

            return Task<Store>.Run<Store>(() => store);
            }
            catch
            {
                return null;
            }

        }
        public Task<List<String>> RetriveCategoriesAsync(int storeId)
        {
            try
            {
                var Categories = _db.Items.Where(c => c.StoreId == storeId).ToList();
                List<string> CategriesNames = new List<string>();
                ItemCategory category = new ItemCategory();
                foreach (var item in Categories)
                {
                    category = _db.ItemCategories.FirstOrDefault(c => c.ItemCategoryId == item.ItemCategoryId);
                    CategriesNames.Add(category.ItemCategoryName);
                }
                return Task.Run(() => CategriesNames);
            }
            catch
            {
                return null;
            }
        }
        public Task<List<Item>> RetriveMenuAsync(int storeId)
        {
            try { 
            var items = _db.Items.Where(c => c.StoreId == storeId).ToList();
            return Task.Run(() => items);
            }
            catch
            {
                return null;
            }
        }
        
        public async Task<Store> PatchAsync(Store Store)
        {
            try { 
            _db = new TalabatContext();
            _db.Stores.Update(Store);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return Store;
            return null;
            }
            catch
            {
                return null;
            }
        }

        public Task<IEnumerable<Item>> RetriveCategoryItemsAsync(int StoreId, int itemCategoryId)
        {
            try { 
            var CategoryItems = _db.Items.Where(x => x.StoreId == StoreId && x.ItemCategoryId == itemCategoryId);
            return Task<IEnumerable>.Run<IEnumerable<Item>>(() => CategoryItems);
            }
            catch
            {
                return null;
            }
        }
    }
}