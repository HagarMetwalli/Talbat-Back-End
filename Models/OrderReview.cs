using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class OrderReview
    {
        public int OrderReviewId { get; set; }
        public int OrderId { get; set; }
        public int OrderPackaging { get; set; }
        public int ValueForMoney { get; set; }
        public int DeliveryTime { get; set; }
        public int QualityOffood { get; set; }
        public string OfferReviewBody { get; set; }

        public virtual Order Order { get; set; }
    }
}
