using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class ItemReview
    {
        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "OrderReviewId is required")]
        [ForeignKey("OrderReview")]
        public int OrderReviewId { get; set; }

        [Required(ErrorMessage = "RateStatusId is required")]
        [ForeignKey("RateStatus")]
        public int RateStatusId { get; set; }

        public virtual OrderReview OrderReview { get; set; }
        public virtual RateStatus RateStatus { get; set; }
    }
}
