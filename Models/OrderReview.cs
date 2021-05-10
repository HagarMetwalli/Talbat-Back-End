using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class OrderReview
    {
        public OrderReview()
        {
            InverseDeliveryTimeNavigation = new HashSet<OrderReview>();
            InverseOrderPackagingNavigation = new HashSet<OrderReview>();
            InverseQualityOffoodNavigation = new HashSet<OrderReview>();
            InverseValueForMoneyNavigation = new HashSet<OrderReview>();
        }

        public int OrderReviewId { get; set; }
        public int OrderId { get; set; }
        public int OrderPackaging { get; set; }
        public int ValueForMoney { get; set; }
        public int DeliveryTime { get; set; }
        public int QualityOffood { get; set; }
        public string OfferReviewBody { get; set; }

        public virtual OrderReview DeliveryTimeNavigation { get; set; }
        public virtual Order Order { get; set; }
        public virtual OrderReview OrderPackagingNavigation { get; set; }
        public virtual OrderReview QualityOffoodNavigation { get; set; }
        public virtual OrderReview ValueForMoneyNavigation { get; set; }
        public virtual ICollection<OrderReview> InverseDeliveryTimeNavigation { get; set; }
        public virtual ICollection<OrderReview> InverseOrderPackagingNavigation { get; set; }
        public virtual ICollection<OrderReview> InverseQualityOffoodNavigation { get; set; }
        public virtual ICollection<OrderReview> InverseValueForMoneyNavigation { get; set; }
    }
}
