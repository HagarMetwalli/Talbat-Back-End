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
    public class StoreService : IStoreService<Store>
    {
        private TalabatContext _db;
        public StoreService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Store> CreatAsync(Store Store)
        {
            await _db.Stores.AddAsync(Store);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return Store;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            Store Store = await RetriveAsync(id);
            _db.Stores.Remove(Store);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IEnumerable<Store>> RetriveAllAsync()
        {
            return Task<IEnumerable>.Run<IEnumerable<Store>>(() => _db.Stores);
        }
        public Task<Store> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Stores.Find(id));
        }

        public Task<IEnumerable<String>> RetriveMostCommonAsync()
        {
            var stores = _db.Stores.OrderByDescending(s => s.StoreOrdersNumber).Take(3).Select(s=>s.StoreName).ToList();
            return Task<IEnumerable>.Run<IEnumerable<String>>(() => stores);
        }
        public Task<Store> RetriveByNameAsync(string storename)
        {
            var store = _db.Stores.FirstOrDefault(s=>s.StoreName==storename);

            return Task<Store>.Run<Store>(() => store);
        }
        public async Task<Store> UpdateAsync(Store Store)
        {
            _db = new TalabatContext();
            _db.Stores.Update(Store);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return Store;
            return null;
        }

    }
}