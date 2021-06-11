using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface ICouponRelatedService : IGeneric<Coupon>
    {
        public int RetrieveCouponDiscountValueAsync(int Id, List<Item> itemsList, int clientId);

    }

}
