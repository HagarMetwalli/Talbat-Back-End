using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class RegionService : IRegions
    {
        private TalabatContext _db;
        public RegionService(TalabatContext db)
        {
            _db = db;
        }

        public Region RetrivebyRegionnameAsync(string regionName)
        {
            try
            {
                var region = _db.Regions.FirstOrDefault(s => s.RegionName == regionName);

                return region;
            }
            catch
            {
                return null;
            }

        }
        public async Task<Region> CreatAsync(Region Region)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    Region reg = RetrivebyRegionnameAsync(Region.RegionName);
                    if (reg != null)
                    {
                        return null;
                    }
                    await _db.Regions.AddAsync(Region);
                    int affected = await _db.SaveChangesAsync();
                    if (affected == 1)
                        return Region;
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
                Region Region = await RetriveAsync(id);
                _db.Regions.Remove(Region);
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

        public Task<List<Region>> RetriveAllAsync()
        {
            try
            {
                return Task<List<Region>>.Run<List<Region>>(() => _db.Regions.ToList());
            }
            catch
            {
                return null; 
            }
        }
        public Task<Region> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.Regions.Find(id));
            }
            catch
            {
                return null;
            }
        }

        public async Task<Region> PatchAsync(Region Region)
        {
            try
            {
                _db = new TalabatContext();
                Region reg = RetrivebyRegionnameAsync(Region.RegionName);
                if (reg != null)
                {
                    return null;
                } 
                _db.Regions.Update(Region);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return Region;
                return null;
            }
            catch
            {
                return null;
            }
        }

    }
}
