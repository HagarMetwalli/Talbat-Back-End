using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class OrderReview
    {
        public OrderReview()
        {
            //InverseDeliveryTimeNavigation = new HashSet<OrderReview>();
            //InverseOrderPackagingNavigation = new HashSet<OrderReview>();
            //InverseQualityOffoodNavigation = new HashSet<OrderReview>();
            //InverseValueForMoneyNavigation = new HashSet<OrderReview>();
        }

        public int OrderReviewId { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [Required]
        [Range(1, 5)]
        public int OrderPackaging { get; set; }

        [Required]
        [Range(1, 5)]
        public int ValueForMoney { get; set; }

        [Required]
        [Range(1, 5)]
        public int DeliveryTime { get; set; }

        [Required]
        [Range(1, 5)]
        public int QualityOffood { get; set; }  

        [Required]
      
        public string OfferReviewBody { get; set; }

        public virtual Order Order { get; set; }
        //public virtual OrderReview DeliveryTimeNavigation { get; set; }
        //public virtual OrderReview OrderPackagingNavigation { get; set; }
        //public virtual OrderReview QualityOffoodNavigation { get; set; }
        //public virtual OrderReview ValueForMoneyNavigation { get; set; }
        //public virtual ICollection<OrderReview> InverseDeliveryTimeNavigation { get; set; }
        //public virtual ICollection<OrderReview> InverseOrderPackagingNavigation { get; set; }
        //public virtual ICollection<OrderReview> InverseQualityOffoodNavigation { get; set; }
        //public virtual ICollection<OrderReview> InverseValueForMoneyNavigation { get; set; }
    }
}
