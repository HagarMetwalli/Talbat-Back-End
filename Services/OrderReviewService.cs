using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class OrderReviewService : IorderReview
    {
        private TalabatContext _db;
        public OrderReviewService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<OrderReview> CreatAsync(OrderReview OrderReview)
        {
            try
            {
                Order order = _db.Orders.Where(a => a.OrderId == OrderReview.OrderId).First();

                if (order.IsDelivered == 1)
                {
                    await _db.OrderReviews.AddAsync(OrderReview);
                    int affected = await _db.SaveChangesAsync();
                    if (affected == 1)
                        return OrderReview;
                    return null;
                }
                else
                {
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
                OrderReview OrderReview = await RetriveAsync(id);
                _db.OrderReviews.Remove(OrderReview);
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

        public Task<List<OrderReview>> RetriveAllAsync()
        {
            try
            {
                return Task<List<OrderReview>>.Run<List<OrderReview>>(() => _db.OrderReviews.ToList());
            }
            catch
            {
                return null;
            }
        }
        public Task<OrderReview> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.OrderReviews.Find(id));
            }
            catch
            {
                return null;
            }
        }

        public async Task<OrderReview> PatchAsync(OrderReview OrderReview)
        {
            try
            {
                _db = new TalabatContext();
                _db.OrderReviews.Update(OrderReview);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return OrderReview;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Task<List<OrderReview>> ALLCommentsForStore (int  storeid)
        {
            try
            {
                List<OrderReview> allreviwes = new List<OrderReview>();
                var allStoreOrder = _db.Orders.Where(a => a.StoreId == storeid && a.IsDelivered ==1).Select(a => a.OrderId).ToList();
                foreach (var item in allStoreOrder)
                {
                    var element = _db.OrderReviews.Where(a => a.OrderId == item).ToList();
                    if (element.Count != 0)
                    {
                        allreviwes.Add(_db.OrderReviews.Where(a => a.OrderId == item).First());
                    }
                    

                }
                return Task<List<OrderReview>>.Run<List<OrderReview>>(() => allreviwes);
            }
            catch
            {
                return null;
            }

        }

    }
}

