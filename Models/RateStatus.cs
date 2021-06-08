using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("RateStatus")]
    public partial class RateStatus
    {
        public RateStatus()
        {
            //ItemReviews = new HashSet<ItemReview>();
            //PromotionReviews = new HashSet<PromotionReview>();
        }

        [Key]
        public int RateStatusId { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string RateStatusName { get; set; }


        [InverseProperty(nameof(ItemReview.RateStatus))]
        public virtual ICollection<ItemReview> ItemReviews { get; set; }

        [InverseProperty(nameof(PromotionReview.RateStatus))]
        public virtual ICollection<PromotionReview> PromotionReviews { get; set; }

    }
}
