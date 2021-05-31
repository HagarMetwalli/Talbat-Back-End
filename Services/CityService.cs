using Microsoft.EntityFrameworkCore;
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
    public class CityService : IGeneric<City>
    {
        private TalabatContext _db;
        public CityService(TalabatContext db)
        {
            _db = db;
        }
        public Task<List<City>> RetriveAllAsync()
        {
            try
            {
                return Task<IList>.Run<List<City>>(() => _db.Cities.ToList());
            }
            catch
            {
                return null;
            }
        }

        public Task<City> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.Cities.Find(id));
            }
            catch
            {
                return null;
            }
        }
        public async Task<City> CreatAsync(City city)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    await db.Cities.AddAsync(city);
                    int affected = await db.SaveChangesAsync();

                    if (affected == 1)
                    {
                        return city;
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
                    City c = await RetriveAsync(id);

                    db.Cities.Remove(c);

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
        public async Task<City> PatchAsync(City city)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    db.Cities.Update(city);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return city;
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
