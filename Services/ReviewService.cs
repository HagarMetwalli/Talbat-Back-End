using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class ReviewService : IGenericService<Review>
    {
        private TalabatContext _db;
        public ReviewService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Review> CreatAsync(Review Review)
        {
            await _db.Reviews.AddAsync(Review);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return Review;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            Review Review = await RetriveAsync(id);
            _db.Reviews.Remove(Review);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IList<Review>> RetriveAllAsync()
        {
            return Task<IList>.Run<IList<Review>>(() => _db.Reviews.ToList());
        }
        public Task<Review> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Reviews.Find(id));
        }

        public async Task<Review> UpdateAsync(Review Review)
        {
            _db = new TalabatContext();
            _db.Reviews.Update(Review);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return Review;
            return null;
        }

    }
}

