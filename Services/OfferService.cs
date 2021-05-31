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
    public class OfferService : IOfferRelatedService
    {
        private TalabatContext _db;
        public OfferService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Offer> CreatAsync(Offer offer)
        {
            await _db.Offers.AddAsync(offer);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return offer;
            return null;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            Offer offer = await RetriveAsync(id);
            _db.Offers.Remove(offer);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return false;
        }

        public Task<List<Offer>> RetriveAllAsync()
        {
            var x = _db.Offers.ToList();
            return Task.Run(() => x);
        }

        public Task<Offer> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Offers.Find(id));
        }

        public async Task<Offer> PatchAsync(Offer offer)
        {
            _db = new TalabatContext();
            _db.Offers.Update(offer);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return offer;
            return null;
        }

        public Store RetrieveOfferStoreAsync(int Id)
        {
            using (var db = new TalabatContext())
            {
                var offerItem = _db.OfferItems.FirstOrDefault(o => o.OfferId == Id && o.ItemId == 4);

                var item = db.Items.Find(offerItem.ItemId);
                //var item = db.Items.Find(l[0].ItemId);
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

    }//end service
}