using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class ReviewCategoryService : IGenericService<ReviewCategory>
    {
        private TalabatContext _db;
        public ReviewCategoryService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<ReviewCategory> CreatAsync(ReviewCategory ReviewCategory)
        {
            await _db.ReviewCategories.AddAsync(ReviewCategory);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return ReviewCategory;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            ReviewCategory ReviewCategory = await RetriveAsync(id);
            _db.ReviewCategories.Remove(ReviewCategory);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IList<ReviewCategory>> RetriveAllAsync()
        {
            return Task<IList>.Run<IList<ReviewCategory>>(() => _db.ReviewCategories.ToList());
        }
        public Task<ReviewCategory> RetriveAsync(int id)
        {
            return Task.Run(() => _db.ReviewCategories.Find(id));
        }

        public async Task<ReviewCategory> UpdateAsync(ReviewCategory ReviewCategory)
        {
            _db = new TalabatContext();
            _db.ReviewCategories.Update(ReviewCategory);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return ReviewCategory;
            return null;
        }

    }
}
