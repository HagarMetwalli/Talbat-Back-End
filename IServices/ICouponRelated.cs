using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface ICouponRelated : IGeneric<Coupon>
    {
        public int RetrieveCouponDiscountValueAsync(string key, List<int> itemsList, int clientId);
        public List<Store> RetriveAllSotresHaveCoupons();
        public List<fullCouponAndItem> RetriveAllSotreCouponItems(int storeId);

    }

}
