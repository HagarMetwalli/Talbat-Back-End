<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
=======
﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
>>>>>>> Hajar
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
<<<<<<< HEAD
    public class StoreService : IGenericService<Store>
    {
        private static ConcurrentDictionary<int, Store> StoresCache;
        private TalabatContext db;

        public StoreService(TalabatContext db)
        {
            this.db = db;
            if (StoresCache == null)
            {
                StoresCache = new ConcurrentDictionary<int, Store>(
                    db.Stores.ToDictionary(o => o.StoreId));
            }
        }

        public async Task<Store> CreatAsync(Store o)
        {
            EntityEntry<Store> added = await db.Stores.AddAsync(o);
            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                return StoresCache.AddOrUpdate(o.StoreId, o, UpdateCache);
            }

            else
            {
                return null;
            }
        }

        private Store UpdateCache(int id, Store o)
        {
            Store old;
            if (StoresCache.TryGetValue(id, out old))
            {
                if (StoresCache.TryUpdate(id, o, old))
                {
                    return o;
                }
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Store c = db.Stores.Find(id);

            db.Stores.Remove(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return StoresCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Store>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<Store>>(() => StoresCache.Values);

        public Task<Store> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                StoresCache.TryGetValue(id, out Store c);
                return c;
            });
        }

        public async Task<Store> UpdateAsync(int id, Store c)
        {
            db.Stores.Update(c);
            db.Stores.Update(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }


    }
}
=======
    public class StoreService : IStoreService
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

        public Task<IEnumerable<String>> RetriveMostCommonStoreAsync()
        {
            var stores = _db.Stores.OrderByDescending(s => s.StoreOrdersNumber).Take(3).Select(s=>s.StoreName).ToList();
            return Task<IEnumerable>.Run<IEnumerable<String>>(() => stores);
        }
        public Task<IEnumerable<object>> RetriveMostCommonCuisineAsync()
        {
            //select Top(2) CuisineId ,sum(StoreOrdersNumber) as total from Store
            //Group by CuisineId
            //Order by total desc
            //var cuisine = _db.Stores.GroupBy(c => c.CuisineId);
            //List<int> CusineTotelNumber = new List<int>();
            //List<int?> Cusinekeys = new List<int?>();
            //foreach (var item in cuisine)
            //{ 
            //    Cusinekeys.Add(item.Key);
               
            //    foreach (var c in item)
            //    {
            //        CusineTotelNumber[Cusinekeys.Count] += c.StoreOrdersNumber;
            //    }
            //}
                  
            //return ;
            var c = new List<object>();
            var cuisine = _db.Stores.AsEnumerable()
                .GroupBy(c => c.CuisineId)
                .ToDictionary(e => e.Key, e => e.ToList());

            foreach (var blabla in cuisine)
            {
                int total = 0;
                foreach (var bla in blabla.Value)
                {
                   
                    total += bla.StoreOrdersNumber;
                }//end bla
                var ol =new  { c= blabla.Key, Total = total };
            c.Add(ol);
            }//end blabla

            return Task<IEnumerable>.Run<IEnumerable<Object>>(() => c);
            //return Task<IEnumerable>.Run<IEnumerable<Object>>(() => c.OrderByDescending(c=>c["item2"]));

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
>>>>>>> Hajar
