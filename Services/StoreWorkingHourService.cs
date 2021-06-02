using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class StoreWorkingHourService : IGeneric<StoreWorkingHour>
    {
        private TalabatContext _db;
        public StoreWorkingHourService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<StoreWorkingHour> CreatAsync(StoreWorkingHour StoreWorkingHour)
        {
            try
            {
                await _db.StoreWorkingHours.AddAsync(StoreWorkingHour);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return StoreWorkingHour;
                return null;
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
                StoreWorkingHour StoreWorkingHour = await RetriveAsync(id);
                _db.StoreWorkingHours.Remove(StoreWorkingHour);
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

        public Task<List<StoreWorkingHour>> RetriveAllAsync()
        {
            try
            {
                return Task<List<StoreWorkingHour>>.Run<List<StoreWorkingHour>>(() => _db.StoreWorkingHours.ToList());
            }
            catch
            {
                return null;
            }
        }
        public Task<StoreWorkingHour> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.StoreWorkingHours.Find(id));
            }
            catch
            {
                return null;
            }
        }

        public async Task<StoreWorkingHour> PatchAsync(StoreWorkingHour StoreWorkingHour)
        {
            try
            {
                _db = new TalabatContext();
                _db.StoreWorkingHours.Update(StoreWorkingHour);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return StoreWorkingHour;
                return null;
            }
            catch
            {
                return null;
            }
        }

    }
}

