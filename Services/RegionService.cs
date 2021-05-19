using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class RegionService : IGenericService<Region>
    {
        private TalabatContext _db;
        public RegionService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Region> CreatAsync(Region Region)
        {
            await _db.Regions.AddAsync(Region);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return Region;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            Region Region = await RetriveAsync(id);
            _db.Regions.Remove(Region);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IEnumerable<Region>> RetriveAllAsync()
        {
            return Task<IEnumerable>.Run<IEnumerable<Region>>(() => _db.Regions);
        }
        public Task<Region> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Regions.Find(id));
        }

        public async Task<Region> UpdateAsync(Region Region)
        {
            _db = new TalabatContext();
            _db.Regions.Update(Region);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return Region;
            return null;
        }

    }
}
