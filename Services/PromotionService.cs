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
    public class PromotionService : IPromotionRelatedService
    {
        private TalabatContext _db;
        public PromotionService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Promotion> CreatAsync(Promotion promotion)
        {
            await _db.Promotions.AddAsync(promotion);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return promotion;
            return null;
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            Promotion promotion = await RetriveAsync(id);
            _db.Promotions.Remove(promotion);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return false;
        }

        public Task<List<Promotion>> RetriveAllAsync()
        {
            var x = _db.Promotions.ToList();
            return Task.Run(() => x);
        }

        public Task<Promotion> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Promotions.Find(id));
        }

        public async Task<Promotion> PatchAsync(Promotion offer)
        {
            _db = new TalabatContext();
            _db.Promotions.Update(offer);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return offer;
            return null;
        }

        public Store RetrieveOfferStoreAsync(int Id)
        {
            using (var db = new TalabatContext())
            {
                var offerItem = _db.PromotionItems.FirstOrDefault(o => o.PromotionId == Id && o.ItemId == 4);

                var item = db.Items.Find(offerItem.ItemId);
                if (item != null)
                {
                    var offerStore = db.Stores.Find(item.StoreId);
                    if (offerStore != null)
                    {
                        return offerStore;
                    }
                }

                return null;
            }

        }

        public List<Store> RetriveAllSotresHavePromotions()
        {
            var stores = _db.Promotions.Join(
                _db.Stores,
                p => p.StoreId,
                s => s.StoreId,
                (prom, sto) => sto
                ).ToList();

            return stores;
        }

        public List<PromotionItem> RetriveAllSotrePromotionItems(int storeId)
        {
            var pi = _db.Items.Where(x => x.StoreId == storeId).ToList().Join(
                _db.PromotionItems,
                i => i.ItemId,
                ci => ci.ItemId,
                (i, ci) => ci
                ).ToList();

            if (pi.Count == 0)
            {
                return null;
            }

            return pi;
        }

    }//end service
}