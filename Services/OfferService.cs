using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class OfferService : IOfferService
    {
        private TalabatContext _db;
        public OfferService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Offer> CreatAsync(Offer Offer)
        {
            await _db.Offers.AddAsync(Offer);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return Offer;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            Offer Offer = await RetriveAsync(id);
            _db.Offers.Remove(Offer);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IEnumerable<Offer>> RetriveAllAsync()
        {
            return Task<IEnumerable>.Run<IEnumerable<Offer>>(() => _db.Offers);
        }
        public Task<Offer> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Offers.Find(id));
        }

        public async Task<Offer> UpdateAsync(Offer Offer)
        {
            _db = new TalabatContext();
            _db.Offers.Update(Offer);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return Offer;
            return null;
        }

        public Task<IEnumerable<Store>> GetAllStoreThatHaveCopon()
        {
            var storeidsForCopon = _db.Offers.Where(s => s.OfferTypeIsCoupon == 1).Select(a => a.StoreId);
            List<Store> temp = _db.Stores.ToList();
            List<Store> stores = new List<Store>();

            foreach (var item in storeidsForCopon)
            {
                for (int i = 0; i < temp.Count(); i++)
                {
                    if (item == temp[i].StoreId)
                    {
                        stores.Add(temp[i]);
                        break;
                    }

                }
            }
            return Task<IEnumerable>.Run<IEnumerable<Store>>(() => stores);
        }
        
        public Task<IEnumerable<Offer>> GetAllCoponsForSpecificStore(int storeid)
        {
            var StoreWithCopon = _db.Offers.Where(a => a.StoreId == storeid && a.OfferTypeIsCoupon == 1);

            return Task<IEnumerable>.Run<IEnumerable<Offer>>(() => StoreWithCopon );

        }

        public Task<IEnumerable<Store>> GetAllStoreThatHavePromotion()
        {
            var storeidsForpromotion = _db.Offers.Where(s => s.OfferTypeIsCoupon == 0).Select(a => a.StoreId);
            List<Store> temp = _db.Stores.ToList();
            List<Store> stores = new List<Store>();

            foreach (var item in storeidsForpromotion)
            {
                for (int i = 0; i < temp.Count(); i++)
                {
                    if (item == temp[i].StoreId)
                    {
                        stores.Add(temp[i]);
                        break;
                    }

                }
            }
            return Task<IEnumerable>.Run<IEnumerable<Store>>(() => stores);
        }

        public Task<IEnumerable<Offer>> GetAllPromotionForSpecificStore(int storeid)
        {
            var StoreWithpromotion = _db.Offers.Where(a => a.StoreId == storeid && a.OfferTypeIsCoupon == 0);

            return Task<IEnumerable>.Run<IEnumerable<Offer>>(() => StoreWithpromotion);

        }



    }
}