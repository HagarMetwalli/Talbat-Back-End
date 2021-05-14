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
    public class DeliveryManService:IGenericService<DeliveryMan>
    {
        private static ConcurrentDictionary<int, DeliveryMan> DeliveryMenCache;
        private TalabatContext db;
        public DeliveryManService(TalabatContext db)
        {
            this.db = db;
            if (DeliveryMenCache == null)
            {
                DeliveryMenCache = new ConcurrentDictionary<int, DeliveryMan>(
                    db.DeliveryMen.ToDictionary(d => d.DeliveryManId));
            }
        }
        public async Task<DeliveryMan> CreatAsync(DeliveryMan c)
        {
            EntityEntry<DeliveryMan> added = await db.DeliveryMen.AddAsync(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return DeliveryMenCache.AddOrUpdate(c.DeliveryManId, c, UpdateCache);
            }
            else
            {
                return null;
            }
        }
        private DeliveryMan UpdateCache(int id, DeliveryMan c)
        {
            DeliveryMan old;
            if (DeliveryMenCache.TryGetValue(id, out old))
            {
                if (DeliveryMenCache.TryUpdate(id, c, old))
                {
                    return c;
                }
            }
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            DeliveryMan c = db.DeliveryMen.Find(id);
            db.DeliveryMen.Remove(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return DeliveryMenCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<DeliveryMan>> RetriveAllAsync() => 
            Task<IEnumerable>.Run<IEnumerable<DeliveryMan>>(() => DeliveryMenCache.Values);

        public Task<DeliveryMan> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                DeliveryMenCache.TryGetValue(id, out DeliveryMan c);
                return c;
            });
        }

        public async Task<DeliveryMan> UpdateAsync(int id, DeliveryMan d)
        {
            db.DeliveryMen.Update(d);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, d);
            }
            return null;
        }

        public Task<DeliveryMan> UpdateAsync(DeliveryMan item)
        {
            throw new System.NotImplementedException();
        }
    }
}

