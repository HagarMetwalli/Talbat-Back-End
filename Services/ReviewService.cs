using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class ReviewService : IGeneric<Review>
    {
        private TalabatContext _db;
        public ReviewService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Review> CreatAsync(Review Review)
        {
            try
            {
                await _db.Reviews.AddAsync(Review);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return Review;
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
                Review Review = await RetriveAsync(id);
                _db.Reviews.Remove(Review);
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

        public Task<List<Review>> RetriveAllAsync()
        {
            try
            {
                return Task<List<Review>>.Run<List<Review>>(() => _db.Reviews.ToList());
            }
            catch
            {
                return null;
            }
        }
        public Task<Review> RetriveAsync(int id)
        {
            try { 
            return Task.Run(() => _db.Reviews.Find(id));
            }
            catch
            {
                return null;
            }
        }

        public async Task<Review> PatchAsync(Review Review)
        {
            try { 
            _db = new TalabatContext();
            _db.Reviews.Update(Review);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return Review;
            return null;
            }
            catch
            {
                return null;
            }
        }

    }
}

