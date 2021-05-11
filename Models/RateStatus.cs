using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class RateStatus
    {
        public RateStatus()
        {
            ItemReviews = new HashSet<ItemReview>();
            OfferReviews = new HashSet<OfferReview>();
        }

        public int RateStatusId { get; set; }
        public string RateStatusName { get; set; }

        public virtual ICollection<ItemReview> ItemReviews { get; set; }
        public virtual ICollection<OfferReview> OfferReviews { get; set; }
    }
}
