using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class OfferReview
    {
        [Key]
        [Column(Order = 1)]
        public int OfferId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int OrderReviewId { get; set; }

        [Key]
        [Column(Order = 3)]
        public int RateStatusId { get; set; }

        public virtual RateStatus RateStatus { get; set; }
    }
}
