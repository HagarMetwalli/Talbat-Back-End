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
    public class ClientOfferService
    {
        private static ConcurrentDictionary<string, ClientOffer> ClientOffersCache;
        private TalabatContext db;
        public ClientOfferService()
        {
            this.db = db;
            if (ClientOffersCache == null)
            {
                ClientOffersCache = new ConcurrentDictionary<string, ClientOffer>(
                    db.ClientOffers.ToDictionary(c => c.UserId.ToString()));
            }
        }
        public async Task<ClientOffer> CreatAsync(ClientOffer c)
        {
            EntityEntry<ClientOffer> added = await db.ClientOffers.AddAsync(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return ClientOffersCache.AddOrUpdate(c.UserId.ToString(), c, UpdateCache);
            }
            else
            {
                return null;
            }
        }
        private ClientOffer UpdateCache(string id, ClientOffer c)
        {
            ClientOffer old;
            if (ClientOffersCache.TryGetValue(id, out old))
            {
                if (ClientOffersCache.TryUpdate(id, c, old))
                {
                    return c;
                }
            }
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            ClientOffer c = db.ClientOffers.Find(id);
            db.ClientOffers.Remove(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return ClientOffersCache.TryRemove(id.ToString(), out c);
            }
            else
            {
                return null;
            }
        }
        public Task<IEnumerable<ClientOffer>> RetriveAllAsync() => 
            Task<IEnumerable>.Run<IEnumerable<ClientOffer>>(() => ClientOffersCache.Values);
        public Task<ClientOffer> RetriveAsync(string id)
        {
            return Task.Run(() =>
            {
                ClientOffersCache.TryGetValue(id, out ClientOffer c);
                return c;
            });
        }
        public async Task<ClientOffer> UpdateAsync(string id, ClientOffer c)
        {
            db.ClientOffers.Update(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }

    }
}
