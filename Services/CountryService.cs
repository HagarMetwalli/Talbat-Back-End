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
    public class CountryService : IGeneric<Country>
    {
        private TalabatContext _db;
        public CountryService(TalabatContext db)
        {
            _db = db;
        }
        public Task<List<Country>> RetriveAllAsync()
        {
            try
            {
                return Task<IList>.Run<List<Country>>(() => _db.Countries.ToList());
            }
            catch 
            {
                return null;
            }
        }
        public Task<Country> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.Countries.Find(id));
            }
            catch 
            {
                return null;
            }
        }
        public async Task<Country> CreatAsync(Country country)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    await _db.Countries.AddAsync(country);
                    int affected = await _db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return country;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<Country> PatchAsync(Country country)
        {
            try
            {
                using(var db = new TalabatContext())
                {
                    db.Countries.Update(country);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return country;
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
                    Country country = await RetriveAsync(id);

                    db.Countries.Remove(country);

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
    }
}
