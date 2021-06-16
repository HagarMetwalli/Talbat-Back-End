using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Talbat.Models
{
    [NotMapped]
    public class fullCouponAndItem
    {
        public Item item{ get; set; }
        public Coupon coupon { get; set; }
    }
}
