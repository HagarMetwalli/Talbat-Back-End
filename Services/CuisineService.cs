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

        public Task<List<Cuisine>> RetriveAllAsync()
        {
            try
            {
                return Task<IList>.Run<List<Cuisine>>(() => _db.Cuisines.ToList());
            }
            catch 
            {
                return null;
            }
        }
        public Task<Cuisine> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.Cuisines.Find(id));
            }
            catch 
            {
                return null;
            }
        }

        public Task<List<string>> RetriveMostCommonAsync()
        {
            try
            {
                var cuisine = _db.Cuisines.OrderByDescending(c => c.TotalOrdersNumber).Take(3).Select(c => c.CuisineName).ToList();

                return Task<IList>.Run<List<string>>(() => cuisine);
            }
            catch
            {
                return null;
            }
        }
        public Task<Cuisine> RetriveByNameAsync(string cuisinename)
        {
            try
            {
                var cuisine = _db.Cuisines.FirstOrDefault(s => s.CuisineName == cuisinename);

                return Task<Cuisine>.Run<Cuisine>(() => cuisine);
            }
            catch
            {
                return null;
            }
        }
        public async Task<Cuisine> CreatAsync(Cuisine cuisine)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    await db.Cuisines.AddAsync(cuisine);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return cuisine;
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
                    Cuisine cuisine = await RetriveAsync(id);
                    db.Cuisines.Remove(cuisine);
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


 
        public async Task<Cuisine> PatchAsync(Cuisine cuisine)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    db.Cuisines.Update(cuisine);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return cuisine;
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