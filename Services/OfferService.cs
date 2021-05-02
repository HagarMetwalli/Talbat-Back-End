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
    public class OfferService:IGenericService<Offer>
    {
        private static ConcurrentDictionary<int, Offer> OffersCache;
        private TalabatContext db;

        public OfferService(TalabatContext db)
        {
            this.db = db;
            if (OffersCache == null)
            {
                OffersCache = new ConcurrentDictionary<int, Offer>(
                    db.Offers.ToDictionary(o => o.OfferId));
            }
        }

        public async Task<Offer> CreatAsync(Offer o)
        {
            EntityEntry<Offer> added = await db.Offers.AddAsync(o);
            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                return OffersCache.AddOrUpdate(o.OfferId, o, UpdateCache);
            }

            else
            {
                return null;
            }
        }

        private Offer UpdateCache(int id, Offer o)
        {
            Offer old;
            if (OffersCache.TryGetValue(id, out old))
            {
                if (OffersCache.TryUpdate(id, o, old))
                {
                    return o;
                }
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Offer c = db.Offers.Find(id);

            db.Offers.Remove(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return OffersCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Offer>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<Offer>>(() => OffersCache.Values);

        public Task<Offer> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                OffersCache.TryGetValue(id, out Offer c);
                return c;
            });
        }

        public async Task<Offer> UpdateAsync(int id, Offer c)
        {
            db.Offers.Update(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }


    }
}
