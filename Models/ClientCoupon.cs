using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("ClientCoupon")]
    public partial class ClientCoupon
    {
        [Key]
        public int ClientId { get; set; }

        [Key]
        public int CouponId { get; set; }


        [ForeignKey(nameof(ClientId))]
        [InverseProperty("ClientCoupons")]
        public virtual Client Client { get; set; }

        [ForeignKey(nameof(CouponId))]
        [InverseProperty("ClientCoupons")]
        public virtual Coupon Coupon { get; set; }
    }
}
