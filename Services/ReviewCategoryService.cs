using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class ReviewCategoryService : IGeneric<ReviewCategory>
    {
        private TalabatContext _db;
        public ReviewCategoryService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<ReviewCategory> CreatAsync(ReviewCategory ReviewCategory)
        {
            try
            {
                await _db.ReviewCategories.AddAsync(ReviewCategory);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return ReviewCategory;
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
                ReviewCategory ReviewCategory = await RetriveAsync(id);
                _db.ReviewCategories.Remove(ReviewCategory);
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

        public Task<List<ReviewCategory>> RetriveAllAsync()
        {
            try
            {
                return Task<List<ReviewCategory>>.Run<List<ReviewCategory>>(() => _db.ReviewCategories.ToList());
            }
            catch
            {
                return null;
            }
        }
        public Task<ReviewCategory> RetriveAsync(int id)
        {
            try { 
            return Task.Run(() => _db.ReviewCategories.Find(id));
            }
            catch
            {
                return null;
            }
        }

        public async Task<ReviewCategory> PatchAsync(ReviewCategory ReviewCategory)
        {
            try { 
            _db = new TalabatContext();
            _db.ReviewCategories.Update(ReviewCategory);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return ReviewCategory;
            return null;
            }
            catch
            {
                return null;
            }
        }

    }
}
