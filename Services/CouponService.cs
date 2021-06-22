using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class CouponService : ICouponRelated
    {
        private TalabatContext _db;
        public CouponService(TalabatContext db)
        {
            _db = db;
        }

        public async Task<Coupon> CreatAsync(Coupon coupon)
        {
            await _db.Coupons.AddAsync(coupon);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return coupon;
            return null;
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            Coupon coupon = await RetriveAsync(id);
            _db.Coupons.Remove(coupon);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return false;
        }

        public Task<List<Coupon>> RetriveAllAsync()
        {
            var x = _db.Coupons.ToList();
            return Task.Run(() => x);
        }

        public Task<Coupon> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Coupons.Find(id));
        }

        public async Task<Coupon> PatchAsync(Coupon coupon)
        {
            _db = new TalabatContext();
            _db.Coupons.Update(coupon);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return coupon;
            return null;
        }

        public  Coupon RetrivebynameAsync(string couponKey)
        {
            try
            {
                var coupon = _db.Coupons.FirstOrDefault(s => s.CouponKey == couponKey);

                return coupon;
            }
            catch
            {
                return null;
            }
         
        }



        public int RetrieveCouponDiscountValueAsync(string couponKey, List<int> itemsIdList, int clientId)
        {
            Coupon coupon = RetrivebynameAsync(couponKey);
            if (coupon == null)
            {
                return 0;
            }
            int Id = coupon.CouponId;

            // NOTE: just for testing
            var itemsList = (from itemId in itemsIdList
                            join itemsOrigin in _db.Items
                            on itemId equals itemsOrigin.ItemId
                            select new { itemsOrigin });
            
            Coupon c = _db.Coupons.Find(Id);

            DateTime CouponExpireDate = c.CouponStartDate.AddDays(c.CouponDaysCount);
            var ExpirationStatus = DateTime.Compare(CouponExpireDate, DateTime.Now);

            if (ExpirationStatus < 0)
            {
                return 0;
            }

            var ClientUsingTimes = _db.ClientCoupons.Where(x => x.ClientId == clientId && x.CouponId == c.CouponId).Count();

            if (ClientUsingTimes >= c.CouponAvailableUsingTimes)
            {
                return 0;
            }

            if (c.IsForAllStoreItems == 1)
            {
                //var ItemsExceededLimit = itemsList.Where(x => (x.ItemPrice * (c.CouponPercentageValue / 100) >= c.CouponMaxMoneyValue).Count();
                //var itemsss = itemsList.Select(x => new { discountForItem = (x.ItemPrice * (c.CouponPercentageValue / 100.0)) , maxDiscountValue = c.CouponMaxMoneyValue }).ToList();
                //var ItemsExceededLimit = itemsss.Count();
                //var ItemsExceededLimit = itemsList.TakeWhile(x => (x.ItemPrice * (c.CouponPercentageValue / 100)) >= c.CouponMaxMoneyValue).Count();
                //int ItemsExceededLimit = 0;
                //foreach (var item in itemsList)
                //{
                //    if ( (item.ItemPrice * (c.CouponPercentageValue / 100)) >= c.CouponMaxMoneyValue )
                //    {
                //        ItemsExceededLimit += 1;
                //    }
                //}
                //NOT GOOD
                //-----------------------------------------------------------------------------------------------------------------------------------
                var TotalDiscount = 0.0;

                var ItemsCount = itemsList.Where(x => x.itemsOrigin.StoreId == c.StoreId).Count();

                var ItemsExceededLimit = itemsList.Count(x => (x.itemsOrigin.ItemPrice * (c.CouponPercentageValue / 100.0)) >= c.CouponMaxMoneyValue);

                TotalDiscount += (c.CouponMaxMoneyValue * ItemsExceededLimit);

                var ItemsDidnotExceededLimit = itemsList.Where(x => ((x.itemsOrigin.ItemPrice) * (c.CouponPercentageValue / 100.0)) < c.CouponMaxMoneyValue).ToList();

                var customDiscounts = ItemsDidnotExceededLimit.Select(x => x.itemsOrigin.ItemPrice * (c.CouponPercentageValue / 100.0)).Sum();

                TotalDiscount += customDiscounts;

                return (int)TotalDiscount;

            }
            else
            {
                var TotalDiscount = 0.0;

                var CouponItemsFound = _db.CouponItems.Where(x => x.CouponId == c.CouponId).ToList();

                //var ItemsFound = from v in CouponItemsFound
                //                 from vOrigin in _db.Items
                //                 .Where(x => x.ItemId == v.ItemId)
                //                 .DefaultIfEmpty()
                //                 .ToList()
                //                 .Select(x => new { x });

                var ItemsFound = from v in CouponItemsFound
                                 join vOrigin in itemsList
                                 on v.ItemId equals vOrigin.itemsOrigin.ItemId
                                 select new { vOrigin };

                var ItemsExceededLimit = ItemsFound.Count(x => (x.vOrigin.itemsOrigin.ItemPrice * (c.CouponPercentageValue / 100.0)) >= c.CouponMaxMoneyValue);

                TotalDiscount += (c.CouponMaxMoneyValue * ItemsExceededLimit);

                var ItemsDidnotExceededLimit = ItemsFound.Where(x => ((x.vOrigin.itemsOrigin.ItemPrice) * (c.CouponPercentageValue / 100.0)) < c.CouponMaxMoneyValue).ToList();

                var customDiscounts = ItemsDidnotExceededLimit.Select(x => x.vOrigin.itemsOrigin.ItemPrice * (c.CouponPercentageValue / 100.0)).Sum();
                
                TotalDiscount += customDiscounts;

                return (int)TotalDiscount;
            }

        }

        public List<Store> RetriveAllSotresHaveCoupons()
        {
            var stores = _db.Coupons.Join(
                _db.Stores,
                p => p.StoreId,
                s => s.StoreId,
                (prom, sto) => sto
                ).ToList();

            return stores;
        }

        public List<fullCouponAndItem> RetriveAllSotreCouponItems(int storeId)
        {
            var ci = _db.Items.Where(x => x.StoreId == storeId).ToList().Join(
                _db.CouponItems,
                i => i.ItemId,
                ci => ci.ItemId,
                (i, ci) => ci
                ).ToList().Join(
                _db.Coupons,
                    ci => ci.CouponId,
                    c => c.CouponId,
                    (coIt, co) => new { couponItem = coIt, coupon = co }
                    ).ToList().Join(
                        _db.Items,
                        couIte => couIte.couponItem.ItemId,
                        i => i.ItemId,
                        (coite, ite) => new fullCouponAndItem() { item = ite, coupon = coite.coupon }
                        ).ToList();

            if (ci.Count == 0)
            {
                return null;
            }

            return ci;
        }

    }//end service
}