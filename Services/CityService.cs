<<<<<<< HEAD
﻿//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using System.Collections;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Talbat.IServices;
//using Talbat.Models;

//namespace Talbat.Services
//{
//    public class CityService : IGenericService<City>
//    {
//        private static ConcurrentDictionary <int, City> CitiesCache;
//        private TalabatContext db;
//        public CityService(TalabatContext db)
//        {
//            this.db = db;
//            if (CitiesCache == null)
//            {
//                CitiesCache = new ConcurrentDictionary<int, City>(
//                    db.Cities.ToDictionary(c => c.CityId));
//            }
//        }
//        public async Task<City> CreatAsync(City c)
//        {
//            EntityEntry<City> added = await db.Cities.AddAsync(c);
//            int affected = await db.SaveChangesAsync();
//            if (affected == 1)
//            {
//                return CitiesCache.AddOrUpdate(c.CityId, c, UpdateCache);
//            }
//            else
//            {
//                return null;
//            }
//        }
//        private City UpdateCache(int id , City c)
//        {
//            City old;
//            if(CitiesCache.TryGetValue(id,out old))
//            {
//                if (CitiesCache.TryUpdate(id, c, old))
//                {
//                    return c;
//                }
//            }
//            return null;
//        }
//        public async Task<bool?> DeleteAsync(int id)
//        {
//            City c = db.Cities.Find(id);
//            db.Cities.Remove(c);
//            int affected = await db.SaveChangesAsync();
//            if (affected == 1)
//            {
//                return CitiesCache.TryRemove(id, out c);
//            }
//            else
//            {
//                return null;
//            }
//        }

//        public Task<IEnumerable<City>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<City>>(() => CitiesCache.Values);

//        public Task<City> RetriveAsync(int id)
//        {
//            return Task.Run(() =>
//            {
//                CitiesCache.TryGetValue(id, out City c);
//                return c;
//            });
//        }

//        public async Task<City> UpdateAsync(int id, City c)
//        {
//            db.Cities.Update(c);
//            int affected = await db.SaveChangesAsync();
//            if (affected == 1)
//            {
//                return UpdateCache(id, c);
//            }
//            return null;
//        }
//    }
//}
=======
﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class CityService : IGenericService<City>
    {
        private TalabatContext _db;
        public CityService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<City> CreatAsync(City city)
        {
            await _db.Cities.AddAsync(city);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return city;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            City c = await RetriveAsync(id);
            _db.Cities.Remove(c);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
             return null;
        }

        public Task<IEnumerable<City>> RetriveAllAsync()
        {
            return Task<IEnumerable>.Run<IEnumerable<City>>(() => _db.Cities);
        }

        public Task<City> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Cities.Find(id));
        }

        public async Task<City> UpdateAsync(City city)
        {
            _db = new TalabatContext();
            _db.Cities.Update(city);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return city;   
            return null;
        }
    }
}
>>>>>>> Hajar
