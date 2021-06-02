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
    public class ItemReviewService : IGeneric<ItemReview>
    {
        private TalabatContext _db;
        public ItemReviewService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<ItemReview> CreatAsync(ItemReview itemReview)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    await db.ItemReviews.AddAsync(itemReview);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return itemReview;
                    }
                    return null;
                }
            }
            catch 
            {
                return null;
            }
        }

        public Task<List<ItemReview>> RetriveAllAsync()
        {
            try
            {
                return Task<IList>.Run<List<ItemReview>>(() => _db.ItemReviews.ToList());
            }
            catch 
            {
                return null;
            }
        }

        public Task<ItemReview> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.ItemReviews.Find(id));
            }
            catch
            {
                return null;
            }
        }

        public async Task<ItemReview> PatchAsync(ItemReview itemReview)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    db.ItemReviews.Update(itemReview);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return itemReview;
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
                    ItemReview itemReview = await RetriveAsync(id);
                    db.ItemReviews.Remove(itemReview);
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
    }
}
