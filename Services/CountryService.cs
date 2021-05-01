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
    public class CountryService : IGenericService<Country>
    {
        private static ConcurrentDictionary<int, Country> CountriesCache;
        private TalabatContext db;
        public CountryService(TalabatContext db)
        {
            this.db = db;
            if (CountriesCache == null)
            {
                CountriesCache = new ConcurrentDictionary<int, Country>(
                    db.Countries.ToDictionary(c => c.CountryId));
            }
        }
        public async Task<Country> CreatAsync(Country c)
        {
            EntityEntry<Country> added = await db.Countries.AddAsync(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return CountriesCache.AddOrUpdate(c.CountryId, c, UpdateCache);
            }
            else
            {
                return null;
            }
        }
        private Country UpdateCache(int id, Country c)
        {
            Country old;
            if (CountriesCache.TryGetValue(id, out old))
            {
                if (CountriesCache.TryUpdate(id, c, old))
                {
                    return c;
                }
            }
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            Country c = db.Countries.Find(id);
            db.Countries.Remove(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return CountriesCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }
        public Task<IEnumerable<Country>> RetriveAllAsync() => 
            Task<IEnumerable>.Run<IEnumerable<Country>>(() => CountriesCache.Values);
        public Task<Country> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                CountriesCache.TryGetValue(id, out Country c);
                return c;
            });
        }

        public async Task<Country> UpdateAsync(int id, Country c)
        {
            db.Countries.Update(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }
    }
}
