using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    [Table("ItemReview")]
  
    public partial class ItemReview
    {
        [Key]
        public int ItemId { get; set; }

        [Key]
        public int OrderReviewId { get; set; }

        [Required]
        public int Rate { get; set; }


        [ForeignKey(nameof(ItemId))]
        [InverseProperty("ItemReviews")]
        public virtual Item Item { get; set; }

        [ForeignKey(nameof(OrderReviewId))]
        [InverseProperty("ItemReviews")]
        public virtual OrderReview OrderReview { get; set; }

       
      
    }
}
