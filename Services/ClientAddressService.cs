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

        private TalabatContext _db;
        public ClientAddressService(TalabatContext db)
        {
           _db = db;
        }
        public async Task<ClientAddress> CreatAsync(ClientAddress clientAddress)
        {
            await _db.ClientAddresses.AddAsync(clientAddress);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return clientAddress;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            ClientAddress clientAddress = await RetriveAsync(id);
            _db.ClientAddresses.Remove(clientAddress);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }
        public Task<IEnumerable<ClientAddress>> RetriveAllAsync()

        {
            return Task<IEnumerable>.Run<IEnumerable<ClientAddress>>(() => _db.ClientAddresses);
        }

        public Task<ClientAddress> RetriveAsync(int id)
        {
            return Task.Run(() => _db.ClientAddresses.Find(id));
        }
        public async Task<ClientAddress> UpdateAsync(ClientAddress clientAddress)
        {
            _db = new TalabatContext();
            _db.ClientAddresses.Update(clientAddress);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return clientAddress;
            return null;
        }
    }

}
