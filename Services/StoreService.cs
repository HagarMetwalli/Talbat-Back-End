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
