using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    [Table("OrderReview")]
    [Index(nameof(DeliveryTime), Name = "IX_OrderReview_DeliveryTime")]
    [Index(nameof(OrderPackaging), Name = "IX_OrderReview_OrderPackaging")]
    [Index(nameof(QualityOfFood), Name = "IX_OrderReview_QualityOFFood")]
    [Index(nameof(ValueForMoney), Name = "IX_OrderReview_ValueForMoney")]
    public partial class OrderReview
    {
        public OrderReview()
        {
            //PromotionReviews = new HashSet<PromotionReview>();
        }

        [Key]
        public int OrderReviewId { get; set; }

        [Required]
        [Range(1, 5), DefaultValue(1)]
        public int OrderPackaging { get; set; }

        [Required]
        [Range(1, 5), DefaultValue(1)]
        public int ValueForMoney { get; set; }

        [Required]
        [Range(1, 5), DefaultValue(1)]
        public int DeliveryTime { get; set; }

        [Required]
        [Range(1, 5), DefaultValue(1)]
        public int QualityOfFood { get; set; }

        [Required]
        [StringLength(maximumLength: 200, MinimumLength = 1)]
        public string OrderReviewComment { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ClientId { get; set; }


        [ForeignKey(nameof(ClientId))]
        [InverseProperty("OrderReviews")]
        public virtual Client Client { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderReviews")]
        public virtual Order Order { get; set; }

        [InverseProperty(nameof(PromotionReview.OrderReview))]
        public virtual ICollection<PromotionReview> PromotionReviews { get; set; }

        [InverseProperty(nameof(ItemReview.OrderReview))]
        public virtual ICollection<ItemReview> ItemReviews { get; set; }
    }
}
