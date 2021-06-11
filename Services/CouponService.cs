using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class CouponService : ICouponRelatedService
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

        public int RetrieveCouponDiscountValueAsync(int Id, List<Item> itemsList, int clientId)
        {
            // NOTE: just for testing
            itemsList = _db.Items.Take(6).ToList();

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
                int TotalDiscount = 0;

                var ItemsCount = itemsList.Where(x => x.StoreId == c.StoreId).Count();

                // NOT GOOD
                //var ItemsExceededLimit = itemsList.Where(x => (x.ItemPrice * (c.CouponPercentageValue / 100) >= c.CouponMaxMoneyValue).Count();
                var itemsss = itemsList.Select(x => new { discountForItem = (x.ItemPrice * (c.CouponPercentageValue / 100.0)) , maxDiscountValue = c.CouponMaxMoneyValue }).ToList();
                var ItemsExceededLimit = itemsss.Count();
                //var ItemsExceededLimit = itemsList.Count(x => (x.ItemPrice * (c.CouponPercentageValue / 100)) >= c.CouponMaxMoneyValue);
                //var ItemsExceededLimit = itemsList.TakeWhile(x => (x.ItemPrice * (c.CouponPercentageValue / 100)) >= c.CouponMaxMoneyValue).Count();
                //int ItemsExceededLimit = 0;
                //foreach (var item in itemsList)
                //{
                //    if ( (item.ItemPrice * (c.CouponPercentageValue / 100)) >= c.CouponMaxMoneyValue )
                //    {
                //        ItemsExceededLimit += 1;
                //    }
                //}
                //-----------------------------------------------------------------------------------------------------------------------------------

                TotalDiscount += (c.CouponMaxMoneyValue * ItemsExceededLimit);
                var ItemsDidnotExceededLimit = itemsList.Where(x => ((x.ItemPrice) * (c.CouponPercentageValue / 100)) < c.CouponMaxMoneyValue).ToList();

                //NOT GOOD
                int customDiscounts = ItemsDidnotExceededLimit.Select(x => x.ItemPrice * (c.CouponPercentageValue / 100)).Sum();
                //-----------------------------------------------------------------------------------------------------------------------------------

                TotalDiscount += customDiscounts;
                return TotalDiscount;
            }
            else
            {
                var CouponItemsFound = _db.CouponItems.Where(x => x.CouponId == c.CouponId).ToList();

                //var ItemsFound = from v in CouponItemsFound
                //                 from vOrigin in _db.Items
                //                 .Where(x => x.ItemId == v.ItemId)
                //                 .DefaultIfEmpty()
                //                 .ToList()
                //                 .Select(x => new { x });

                var ItemsFound = from v in CouponItemsFound
                                 join vOrigin in _db.Items
                                 on v.ItemId equals vOrigin.ItemId
                                 select new { vOrigin };

                int customDiscounts = ItemsFound.Select(x => x.vOrigin.ItemPrice * (c.CouponPercentageValue / 100)).Sum();

                return customDiscounts;
            }

        }


    }//end service
}