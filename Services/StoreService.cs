using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class StoreService : IGenericService<Store>
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

        public Task<IEnumerable<Store>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<Store>>(() => StoresCache.Values);

        public Task<Store> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Stores.Find(id));
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
