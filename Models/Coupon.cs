using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("Coupon")]
    public partial class Coupon
    {
        public Coupon()
        {
            //ClientCoupons = new HashSet<ClientCoupon>();
            //CouponItems = new HashSet<CouponItem>();
        }

        [Key]
        public int CouponId { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string CouponKey { get; set; }

        [Required]
        public DateTime CouponStartDate { get; set; }

        [Required]
        [Range(1, 30)]
        public int CouponDaysCount { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CouponAvailableUsingTimes { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CouponMaxMoneyValue { get; set; }

        [Required]
        [Range(0, 1)]
        public int IsForAllStoreItems { get; set; }

        [Required]
        [ForeignKey("Store")]
        public int StoreId { get; set; }


        [ForeignKey(nameof(StoreId))]
        [InverseProperty("Coupons")]
        public virtual Store Store { get; set; }

        [InverseProperty(nameof(ClientCoupon.Coupon))]
        public virtual ICollection<ClientCoupon> ClientCoupons { get; set; }

        [InverseProperty(nameof(CouponItem.Coupon))]
        public virtual ICollection<CouponItem> CouponItems { get; set; }
    }
}
