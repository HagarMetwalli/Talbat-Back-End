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
    public class StoreTypeService : IGenericService<StoreType>
    {
        private static ConcurrentDictionary<int, StoreType> StoreTypesCache;
        private TalabatContext db;

        public StoreTypeService(TalabatContext db)
        {
            this.db = db;
            if (StoreTypesCache == null)
            {
                StoreTypesCache = new ConcurrentDictionary<int, StoreType>(
                    db.StoreTypes.ToDictionary(o => o.StoreTypeId));
            }
        }

        public async Task<StoreType> CreatAsync(StoreType o)
        {
            EntityEntry<StoreType> added = await db.StoreTypes.AddAsync(o);
            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                return StoreTypesCache.AddOrUpdate(o.StoreTypeId, o, UpdateCache);
            }

            else
            {
                return null;
            }
        }

        private StoreType UpdateCache(int id, StoreType o)
        {
            StoreType old;
            if (StoreTypesCache.TryGetValue(id, out old))
            {
                if (StoreTypesCache.TryUpdate(id, o, old))
                {
                    return o;
                }
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            StoreType c = db.StoreTypes.Find(id);

            db.StoreTypes.Remove(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return StoreTypesCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<StoreType>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<StoreType>>(() => StoreTypesCache.Values);

        public Task<StoreType> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                StoreTypesCache.TryGetValue(id, out StoreType c);
                return c;
            });
        }

        public async Task<StoreType> UpdateAsync(int id, StoreType c)
        {
            db.StoreTypes.Update(c);
            db.StoreTypes.Update(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }


    }
}
