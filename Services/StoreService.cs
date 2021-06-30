using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
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

        public async Task<Store> CreateStoreAsync(Store store)
        {
            try
            { 
                using (var db = new TalabatContext())
                {
                    await db.Stores.AddAsync(store);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return store;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }

        }
        public async Task<Store> PatchStoreAsync(Store store ,IFormFile imgFile)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    if (imgFile == null)
                    {
                        var _store = db.Stores.Single(i => i.StoreId == store.StoreId);
                        store.StoreImage = _store.StoreImage;
                        db.SaveChanges();
                        return  await Task.Run(() => store);
                    }
                    db.Stores.Update(store);

                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        if (imgFile != null)
                        {
                            if (imgFile.Length > 0)
                            {
                                //Getting FileName
                                var fileName = Path.GetFileName(imgFile.FileName);

                                ////Assigning Unique Filename (Guid)
                                //var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                                //Getting file Extension
                                var fileExtension = Path.GetExtension(fileName);

                                // concatenating  FileName + FileExtension
                                var newFileName = String.Concat(store.StoreId, fileExtension);
                                store.StoreImage = "https://localhost:44311/Images/Stores/" + newFileName;

                                // Combines two strings into a path.
                                var filepath =
                                new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images/Stores")).Root + $@"\{newFileName}";

                                using (FileStream fs = System.IO.File.Create(filepath))
                                {
                                    imgFile.CopyTo(fs);
                                    fs.Flush();
                                }
                                db.SaveChanges();
                                return store;
                            }

                            return store;

                        }
                        return null;
                    }
                    return store;
                }
            }

            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {

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
                return Task<List<Store>>.Run<List<Store>>(() => _db.Stores
                .Include("Cuisine")
                .ToList());
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
                  
                return Task.Run(() => _db.Stores.Include("Cuisine")
                .Include("Country")
                .Include("StoreType")
                .Single(s=>s.StoreId==id));
            }
            catch
            {
                return null;
            }

        }
        public Task<List<Item>> RetriveAllWithNameAsync(int id)
        {
            try
            {
                return Task<IList>.Run<List<Item>>(() => _db.Items
                .Include("ItemCategory")
                .Include("Country")
                .Where(s=>s.StoreId==id)
                .ToList());
            }
            catch
            {
                return null;
            }
        }

        public Task<IEnumerable<String>> RetriveMostCommonAsync()
        {
            try
            {
                var stores = _db.Stores.OrderByDescending(s => s.StoreOrdersNumber).Take(5).Select(s => s.StoreName).ToList();
                return Task<IEnumerable>.Run<IEnumerable<String>>(() => stores);
            }
            catch
            {
                return null;
            }
        }
        public Task<List<Item>> RetriveTopItemsAsync(int storeId)
        {
            try
            {
                List<Item> resulte = new List<Item>();
                var _items = _db.Items.Where(i => i.StoreId == storeId).ToList();

                for (var i = 0; i < _items.Count(); i++)
                {
                    var all_Order_That_Have_Item = _db.OrderItems.Where(q => q.ItemId == _items[i].ItemId);
                    var numberOfOrdere = all_Order_That_Have_Item.Count();
                    for (var j = i + 1; j < _items.Count(); j++)
                    {
                        var all_Order_That_Have_sec_Item = _db.OrderItems.Where(q => q.ItemId == _items[j].ItemId);
                        var numberOfOrdereForSec = all_Order_That_Have_sec_Item.Count();
                         
                        if (numberOfOrdereForSec > numberOfOrdere)
                        {
                             var temp = _items[i];
                            _items[i] = _items[j];
                            _items[j] = temp;
                            //resulte.Add(_items[j]);


                        }
                    }
                }

                return Task<IList<Item>>.Run<List<Item>>(() => _items);
            }
            catch
            {
                return null;
            }
        }
        //public Task<List<Store>> RetriveStorebyFilter(string filter)
        //{
        //    try
        //    {

        //        return null;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        public Task<List<Store>> RetriveStoreWithTypeIdAsync(int storeTypeId)
        {
            try
            {
                var stores = _db.Stores.Where(s => s.StoreTypeId == storeTypeId).ToList();

                return Task<IList<Store>>.Run<List<Store>>(() => stores);
            }
            catch
            {
                return null;
            }
        }
        public Task<List<Store>> RetriveStoreWithCuisineIdAsync(int CuisineId)
        {
            try
            {

                var stores = _db.Stores.Where(s => s.CuisineId == CuisineId).ToList();

                return Task<IList<Store>>.Run<List<Store>>(() => stores);
            }
            catch
            {
                return null;
            }
        }

        public Task<Store> RetriveByNameAsync(string storename)
        {
            try
            {
                var store = _db.Stores.FirstOrDefault(s => s.StoreName == storename);

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
                var Categries = _db.Items.Include("ItemCategory").Where(c => c.StoreId == storeId)
                .Select(x => x.ItemCategory).Distinct().ToList();
                List<string> CategriesNames = new List<string>();
                foreach (var category in Categries)
                {
                    CategriesNames.Add(category.ItemCategoryName);
                }
                return Task.Run(() => CategriesNames);
            }
            catch
            {
                return null;
            }
        }
        public Task<List<ItemCategory>> RetriveItemCategoriesAsync(int storeId)
         {
            try
            {
                var Categries = _db.Items.Include("ItemCategory").Where(c => c.StoreId == storeId)
                    .Select(x => x.ItemCategory).Distinct().ToList();
                return Task.Run(() => Categries);
            }
            catch
            {
                return null;
            }
        }
        public Task<List<Item>> RetriveMenuAsync(int storeId)
        {
            try
            {
                var items = _db.Items.Where(c => c.StoreId == storeId).ToList();
                return Task.Run(() => items);
            }
            catch
            {
                return null;
            }
        }

        //public async Task<Store> PatchAsync(Store Store)
        //{
        //    try
        //    {
        //        _db = new TalabatContext();
        //        _db.Stores.Update(Store);
        //        int affected = await _db.SaveChangesAsync();
        //        if (affected == 1)
        //            return Store;
        //        return null;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        public Task<IEnumerable<Item>> RetriveCategoryItemsAsync(int StoreId, int itemCategoryId)
        {
            try
            {
                var CategoryItems = _db.Items.Where(x => x.StoreId == StoreId && x.ItemCategoryId == itemCategoryId);
                return Task<IEnumerable>.Run<IEnumerable<Item>>(() => CategoryItems);
            }
            catch
            {
                return null;
            }
        }

        public Task<List<Store>> RetriveStoresBasedLocationAsync(double lat1, double long1)
        {
            try
            {
                List<Store> stores = _db.Stores.ToList();
                List<Store> nearestStores = new List<Store> { };
                foreach (var store in stores)
                {
                    double destanceInMeters = getDistanceFromLatLonInMeter(lat1, long1, store.StoreLatitude, store.StoreLongitude);
                    if (destanceInMeters <= store.StoreDeliveryDistance)
                    {
                        nearestStores.Add(store);
                    }

                }
                return Task<List<Store>>.Run<List<Store>>(() => nearestStores);
            }
            catch
            {
                return null;
            }
        }
        public Task<Store> RetriveStoreInLocationAsync(int storeId, double lat1, double long1)
        {
            try
            {
                var store = _db.Stores.Single(x => x.StoreId == storeId);

                double destanceInMeters = getDistanceFromLatLonInMeter(lat1, long1, store.StoreLatitude, store.StoreLongitude);
                if (destanceInMeters <= store.StoreDeliveryDistance)
                {
                    return Task<Store>.Run<Store>(() => store);
                }
                return null;

            }
            catch
            {
                return null;
            }
        }

        public double getDistanceFromLatLonInMeter(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371; // Radius of the earth in km
            var dLat = deg2rad(lat2 - lat1);  // deg2rad below
            var dLon = deg2rad(lon2 - lon1);
            var a =
              Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) *
              Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
              ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c; // Distance in km
            return d * 1000;
        }

        public double deg2rad(double deg)
        {
            return deg * (Math.PI / 180);
        }


    }
}