using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;
namespace Talbat.Services
{
    public class AddressTypeService :IAddressType
    {
        private TalabatContext _db;

        public AddressTypeService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<AddressType> CreatAsync(AddressType addressType)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    await db.AddressTypes.AddAsync(addressType);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return addressType;
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
                AddressType addressType = await RetriveAsync(id);
                using (var db = new TalabatContext())
                {
                    db.AddressTypes.Remove(addressType);
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

        public Task<AddressType> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.AddressTypes.Find(id)); 
            }
            catch 
            {
                return null;
            }
        }

        public async Task<AddressType> PatchAsync(AddressType addressType)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    db.AddressTypes.Update(addressType);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return addressType;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }

        }
    }
}
