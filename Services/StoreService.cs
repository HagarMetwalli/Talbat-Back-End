using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public Task<IEnumerable<string>> RetriveMostCommonStoreAsync()
        {
            var stores = _db.Stores.OrderByDescending(s => s.StoreOrdersNumber).Take(3).Select(s=>s.StoreName).ToList();
            return Task<IEnumerable>.Run<IEnumerable<string>>(() => stores);
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

            return Task.Run<IEnumerable<object>>(() => c);
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

        Task<IEnumerable<string>> IStoreService.RetriveMostCommonStoreAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Item>> RetrieveStoreMenuItemsAsync(int id)
        {
            using (var db = new TalabatContext())
            {
                var storeRequired = db.Stores.Find(id);

                if (storeRequired != null)
                {
                    var itemsList = db.Items.Select(item => item).Where(x => x.StoreId == id).ToList();
                    return Task.Run<List<Item>>(() => itemsList);
                }
                return null;
            }
        }
    }
}
