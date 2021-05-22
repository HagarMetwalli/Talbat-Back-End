using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class StoreWorkingHourService : IGenericService<StoreWorkingHour>
    {
        private TalabatContext _db;
        public StoreWorkingHourService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<StoreWorkingHour> CreatAsync(StoreWorkingHour StoreWorkingHour)
        {
            await _db.StoreWorkingHours.AddAsync(StoreWorkingHour);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return StoreWorkingHour;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            StoreWorkingHour StoreWorkingHour = await RetriveAsync(id);
            _db.StoreWorkingHours.Remove(StoreWorkingHour);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IList<StoreWorkingHour>> RetriveAllAsync()
        {
            return Task<IList>.Run<IList<StoreWorkingHour>>(() => _db.StoreWorkingHours.ToList());
        }
        public Task<StoreWorkingHour> RetriveAsync(int id)
        {
            return Task.Run(() => _db.StoreWorkingHours.Find(id));
        }

        public async Task<StoreWorkingHour> UpdateAsync(StoreWorkingHour StoreWorkingHour)
        {
            _db = new TalabatContext();
            _db.StoreWorkingHours.Update(StoreWorkingHour);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return StoreWorkingHour;
            return null;
        }

    }
}

