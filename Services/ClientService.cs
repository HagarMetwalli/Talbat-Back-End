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
       // private static ConcurrentDictionary<int,Client> ClientsCache;
        private TalabatContext _db;
        public ClientService(TalabatContext db)
        {
            _db = db;
        }
        public Task<IEnumerable<Client>> RetriveAllAsync()
        {
            return Task<IEnumerable>.Run<IEnumerable<Client>>(() => _db.Clients);
        }

        public Task<Client> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Clients.Find(id));
        }

        public async Task<Client> CreatAsync(Client client)
        {
            await _db.Clients.AddAsync(client);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return client;
            return null;
        }
        public async Task<Client> UpdateAsync(Client client)
        {
            _db = new TalabatContext();
            _db.Clients.Update(client);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return client;
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Client client = await RetriveAsync(id);
            _db.Clients.Remove(client);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }
    }
}
