using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class OfferReview
    {
        public int OfferId { get; set; }
        public int OrderReviewId { get; set; }
        public int RateStatusId { get; set; }

        public virtual RateStatus RateStatus { get; set; }
    }
}
