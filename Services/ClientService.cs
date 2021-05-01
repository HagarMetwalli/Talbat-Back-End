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
    public class ClientService: IGenericService<Client>
    {
        private static ConcurrentDictionary<int,Client> ClientsCache;
        private TalabatContext db;
        public ClientService(TalabatContext db)
        {
            this.db = db;
            if (ClientsCache == null)
            {
                ClientsCache = new ConcurrentDictionary<int, Client>(
                    db.Clients.ToDictionary(c => c.ClientId));
            }
        }

        public async Task<Client> CreatAsync(Client c)
        {
            EntityEntry<Client> added = await db.Clients.AddAsync(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return ClientsCache.AddOrUpdate(c.ClientId, c, UpdateCache);
            }
            else
            {
                return null;
            }
        }
        private Client UpdateCache(int id, Client c)
        {
            Client old;
            if (ClientsCache.TryGetValue(id, out old))
            {
                if (ClientsCache.TryUpdate(id, c, old))
                {
                    return c;
                }
            }
            return null;


        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Client c = db.Clients.Find(id);
            db.Clients.Remove(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return ClientsCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Client>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<Client>>(() => ClientsCache.Values);


        public Task<Client> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                ClientsCache.TryGetValue(id, out Client c);
                return c;
            });
        }
        public async Task<Client> UpdateAsync(int id, Client c)
        {
            db.Clients.Update(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }
    }
}
