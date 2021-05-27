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
    public class CountryService : IGenericService<Country>
    {
        private TalabatContext _db;
        public CountryService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Country> CreatAsync(Country country)
        {
            await _db.Countries.AddAsync(country);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return country;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            Country country = await RetriveAsync(id);
            _db.Countries.Remove(country);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }
        public Task<IList<Country>> RetriveAllAsync()
        {
            return Task<IList>.Run<IList<Country>>(() => _db.Countries.ToList());
        }
        public Task<Country> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Countries.Find(id));
        }

        public async Task<Country> UpdateAsync(Country country)
        {
            _db = new TalabatContext();
            _db.Countries.Update(country);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return country;
            return null;
        }
    }
}
