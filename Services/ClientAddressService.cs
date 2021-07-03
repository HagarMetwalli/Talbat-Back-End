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
    public class ClientAddressService: IClientAddressesRelated
    {

        private TalabatContext _db;
        public ClientAddressService(TalabatContext db)
        {
           _db = db;
        }
        
        public Task<List<ClientAddress>> RetriveAllAsync()
        {
            try
            {
                return Task<IList>.Run<List<ClientAddress>>(() => _db.ClientAddresses.ToList());
            }
            catch
            {
                return null;
            }
        }

        public Task<ClientAddress> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.ClientAddresses.Find(id));
            }
            catch
            {
                return null;
            }
        }

        

        public async Task<ClientAddress> CreatAsync(ClientAddress clientAddress)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    await db.ClientAddresses.AddAsync(clientAddress);

                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return clientAddress;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }

        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    ClientAddress clientAddress = await RetriveAsync(id);
                    db.ClientAddresses.Remove(clientAddress);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1) 
                    { 
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<ClientAddress> PatchAsync(ClientAddress clientAddress)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    db.ClientAddresses.Update(clientAddress);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return clientAddress;
                    }
                    return null;
                }
            }
            catch 
            {
                return null;
            }

        }

        public List<ClientAddress> RetriveByClientIdAsync(int id)
        {
            try
            {
                return _db.ClientAddresses.Where(x => x.ClientId == id).ToList();
            }
            catch
            {
                return null;
            }
            

        }
    }

}
