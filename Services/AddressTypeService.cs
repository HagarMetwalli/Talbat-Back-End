using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;
namespace Talbat.Services
{
    public class AddressTypeService : IGenericService<AddressType>
    {
        private TalabatContext _db;

        public AddressTypeService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<AddressType> CreatAsync(AddressType addressType)
        {
            await _db.AddressTypes.AddAsync(addressType);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return addressType;
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            AddressType addressType = await RetriveAsync(id);
            _db.AddressTypes.Remove(addressType);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IEnumerable<AddressType>> RetriveAllAsync()
        {
            return Task<IEnumerable>.Run<IEnumerable<AddressType>>(() => _db.AddressTypes);
        }

        public Task<AddressType> RetriveAsync(int id)
        {
            return Task.Run(() => _db.AddressTypes.Find(id));
        }

        public async Task<AddressType> UpdateAsync(AddressType addressType)
        {
            _db = new TalabatContext();
            _db.AddressTypes.Update(addressType);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return addressType;
            return null;
        }
    }
}
