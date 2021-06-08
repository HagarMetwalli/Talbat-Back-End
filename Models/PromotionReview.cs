using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    [Table("PromotionReview")]
    [Index(nameof(RateStatusId), Name = "IX_OfferReview_RateStatus_Id")]
    public partial class PromotionReview
    {
        [Key]
        public int PromotionId { get; set; }

        [Key]
        public int OrderReviewId { get; set; }

        [Required]
        public int RateStatusId { get; set; }


        [ForeignKey(nameof(OrderReviewId))]
        [InverseProperty("PromotionReviews")]
        public virtual OrderReview OrderReview { get; set; }

        [ForeignKey(nameof(PromotionId))]
        [InverseProperty("PromotionReviews")]
        public virtual Promotion Promotion { get; set; }

        [ForeignKey(nameof(RateStatusId))]
        [InverseProperty("PromotionReviews")]
        public virtual RateStatus RateStatus { get; set; }

    }
}
