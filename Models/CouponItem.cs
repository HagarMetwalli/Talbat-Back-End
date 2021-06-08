using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    [Table("CouponItem")]
    public partial class CouponItem
    {
        [Key]
        public int CouponId { get; set; }

        [Key]
        public int ItemId { get; set; }


        [ForeignKey(nameof(CouponId))]
        [InverseProperty("CouponItems")]
        public virtual Coupon Coupon { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty("CouponItems")]
        public virtual Item Item { get; set; }
    }
}
