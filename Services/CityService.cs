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
    public class CityService : IGenericService<City>
    {
        private TalabatContext _db;
        public CityService(TalabatContext db):base()
        {
            _db = db;
        }
        public async Task<City> CreatAsync(City city)
        {
            await _db.Cities.AddAsync(city);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return city;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            City c = await RetriveAsync(id);
            _db.Cities.Remove(c);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
             return null;
        }

        public Task<IEnumerable<City>> RetriveAllAsync()
        {
            return Task<IEnumerable>.Run<IEnumerable<City>>(() => _db.Cities);
        }

        public Task<City> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Cities.Find(id));
        }

        public async Task<City> UpdateAsync(int id ,City c)
        {
            TalabatContext _dbc = new TalabatContext();
            _dbc.Cities.Update(c);
            int affected = await _dbc.SaveChangesAsync();
            if (affected == 1)
                return c;   
            return null;
        }

    }
}
