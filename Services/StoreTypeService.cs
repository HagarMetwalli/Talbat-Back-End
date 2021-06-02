using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class StoreTypeService : IGeneric<StoreType>
    {
        private TalabatContext _db;
        public StoreTypeService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<StoreType> CreatAsync(StoreType StoreType)
        {
            //try
            //{
                await _db.StoreTypes.AddAsync(StoreType);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return StoreType;
                return null;
            //}
            //catch
            //{
            //    return null;
            //}
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try { 
            StoreType StoreType = await RetriveAsync(id);
            _db.StoreTypes.Remove(StoreType);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return false;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<StoreType>> RetriveAllAsync()
        {
            try
            {
                return Task<List<StoreType>>.Run<List<StoreType>>(() => _db.StoreTypes.ToList());
            }
            catch
            {
                return null;
            }
        }
        public Task<StoreType> RetriveAsync(int id)
        {
            try { 
            return Task.Run(() => _db.StoreTypes.Find(id));
            }
            catch
            {
                return null;
            }
        }

        public async Task<StoreType> PatchAsync(StoreType StoreType)
        {
            try { 
            _db = new TalabatContext();
            _db.StoreTypes.Update(StoreType);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return StoreType;
            return null;
            }
            catch
            {
                return null;
            }
        }

    }
}

