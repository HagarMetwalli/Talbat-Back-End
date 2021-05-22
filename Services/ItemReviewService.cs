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
    public class ItemReviewService : IGenericService<ItemReview>
    {
        private TalabatContext _db;
        public ItemReviewService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<ItemReview> CreatAsync(ItemReview itemReview)
        {
            await _db.ItemReviews.AddAsync(itemReview);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return itemReview;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            ItemReview itemReview = await RetriveAsync(id);
            _db.ItemReviews.Remove(itemReview);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IList<ItemReview>> RetriveAllAsync()
        {
            return Task<IList>.Run<IList<ItemReview>>(() => _db.ItemReviews.ToList());
        }

        public Task<ItemReview> RetriveAsync(int id)
        {
            return Task.Run(() => _db.ItemReviews.Find(id));
        }

        public async Task<ItemReview> UpdateAsync(ItemReview itemReview)
        {
            _db = new TalabatContext();
            _db.ItemReviews.Update(itemReview);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return itemReview;
            return null;
        }
    }
}
