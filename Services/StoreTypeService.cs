using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class StoreTypeService : IGenericService<StoreType>
    {
        private TalabatContext _db;
        public StoreTypeService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<StoreType> CreatAsync(StoreType StoreType)
        {
            await _db.StoreTypes.AddAsync(StoreType);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return StoreType;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            StoreType StoreType = await RetriveAsync(id);
            _db.StoreTypes.Remove(StoreType);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IList<StoreType>> RetriveAllAsync()
        {
            return Task<IEnumerable>.Run<IList<StoreType>>(() => _db.StoreTypes.ToList());
        }
        public Task<StoreType> RetriveAsync(int id)
        {
            return Task.Run(() => _db.StoreTypes.Find(id));
        }

        public async Task<StoreType> UpdateAsync(StoreType StoreType)
        {
            _db = new TalabatContext();
            _db.StoreTypes.Update(StoreType);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return StoreType;
            return null;
        }

    }
}

