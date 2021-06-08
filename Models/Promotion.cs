using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("Promotion")]
    public partial class Promotion
    {
        public Promotion()
        {
            //ClientOffers = new HashSet<ClientOffer>();
            //ClientPromotions = new HashSet<ClientPromotion>();
            //PromotionItems = new HashSet<PromotionItem>();
            //PromotionReviews = new HashSet<PromotionReview>();
        }

        [Key]
        public int PromotionId { get; set; }

        [Required]
        [DefaultValue("promotion.png")]
        public string PromotionImage { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string PromotionName { get; set; }

        [Required]
        [StringLength(maximumLength: 200, MinimumLength = 1)]
        public string PromotionDescription { get; set; }

        [Required]
        public DateTime PromotionStartDate { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PromotionDaysNumber { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PromotionQuantity { get; set; }

        [Required]
        [Range(0, 1)]
        public int PromotionTypePercentage { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PromotionSaleValue { get; set; }


        [InverseProperty(nameof(ClientPromotion.Promotion))]
        public virtual ICollection<ClientPromotion> ClientPromotions { get; set; }

        [InverseProperty(nameof(PromotionItem.Promotion))]
        public virtual ICollection<PromotionItem> PromotionItems { get; set; }

        [InverseProperty(nameof(PromotionReview.Promotion))]
        public virtual ICollection<PromotionReview> PromotionReviews { get; set; }

    }
}
