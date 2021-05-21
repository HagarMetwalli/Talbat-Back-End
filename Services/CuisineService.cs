using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class CuisineService : ICuisienSevice
    {
        private TalabatContext _db;
        public CuisineService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Cuisine> CreatAsync(Cuisine cuisine)
        {
            await _db.Cuisines.AddAsync(cuisine);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return cuisine;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            Cuisine cuisine = await RetriveAsync(id);
            _db.Cuisines.Remove(cuisine);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }


        public Task<IEnumerable<Cuisine>>  RetriveAllAsync()
        {
            return Task<IEnumerable>.Run<IEnumerable<Cuisine>>(() => _db.Cuisines);
        }
        public Task<Cuisine> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Cuisines.Find(id));
        }

        public Task<IEnumerable<String>> RetriveMostCommonAsync()
        {
            var cuisine = _db.Cuisines.OrderByDescending(c => c.TotalOrdersNumber).Take(3).Select(c => c.CuisineName).ToList();

            return Task<IEnumerable>.Run<IEnumerable<String>>(() => cuisine);
        }
        public Task<Cuisine> RetriveByNameAsync(string cuisinename)
        {
            var cuisine = _db.Cuisines.FirstOrDefault(s => s.CuisineName == cuisinename);

            return Task<Cuisine>.Run<Cuisine>(() => cuisine);
        }
        public async Task<Cuisine> UpdateAsync(Cuisine cuisine)
        {
            _db = new TalabatContext();
            _db.Cuisines.Update(cuisine);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return cuisine;
            return null;
        }

        public Task<List<string>> RetriveCategoriesAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}