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
    public class ClientAddressService: IGenericService<ClientAddress>
    {
        private static ConcurrentDictionary<int, ClientAddress> ClientAddressessCache;
        private TalabatContext db;
        public ClientAddressService(TalabatContext db)
        {
            this.db = db;
            if (ClientAddressessCache == null)
            {
                ClientAddressessCache = new ConcurrentDictionary<int, ClientAddress>(
                    db.ClientAddresses.ToDictionary(c =>c.ClientAddressId));
            }

        }
        public async Task<ClientAddress> CreatAsync(ClientAddress c)
        {
            EntityEntry<ClientAddress> added = await db.ClientAddresses.AddAsync(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return ClientAddressessCache.AddOrUpdate(c.ClientAddressId, c, UpdateCache);
            }
            else
            {
                return null;
            }
        }
        private ClientAddress UpdateCache(int id, ClientAddress c)
        {
            ClientAddress old;
            if (ClientAddressessCache.TryGetValue(id, out old))
            {
                if (ClientAddressessCache.TryUpdate(id, c, old))
                {
                    return c;
                }
            }
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            ClientAddress c = db.ClientAddresses.Find(id);
            db.ClientAddresses.Remove(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return ClientAddressessCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }
        public Task<IEnumerable<ClientAddress>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<ClientAddress>>(() => ClientAddressessCache.Values);

        public Task<ClientAddress> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                ClientAddressessCache.TryGetValue(id, out ClientAddress c);
                return c;
            });
        }
        public async Task<ClientAddress> UpdateAsync(int id, ClientAddress c)
        {
            db.ClientAddresses.Update(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }
    }

}
