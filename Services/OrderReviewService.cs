using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class OrderReviewService : IGenericService<OrderReview>
    {
        private TalabatContext _db;
        public OrderReviewService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<OrderReview> CreatAsync(OrderReview OrderReview)
        {
            await _db.OrderReviews.AddAsync(OrderReview);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return OrderReview;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            OrderReview OrderReview = await RetriveAsync(id);
            _db.OrderReviews.Remove(OrderReview);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IList<OrderReview>> RetriveAllAsync()
        {
            return Task<IList>.Run<IList<OrderReview>>(() => _db.OrderReviews.ToList());
        }
        public Task<OrderReview> RetriveAsync(int id)
        {
            return Task.Run(() => _db.OrderReviews.Find(id));
        }

        public async Task<OrderReview> UpdateAsync(OrderReview OrderReview)
        {
            _db = new TalabatContext();
            _db.OrderReviews.Update(OrderReview);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return OrderReview;
            return null;
        }

    }
}

