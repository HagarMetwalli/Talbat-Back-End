using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }

        [Required]
        public string ReviewContent { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ReviewDate { get; set; }

        [Required]
        [Range(1,5)]
        public double ReviewRates { get; set; }

        [Required]
        [ForeignKey("ReviewCategory")]
        public int ReviewCategoryId { get; set; }

        [Required]
        [ForeignKey("Client")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Store")]
        public int StoreId { get; set; }

        public virtual ReviewCategory ReviewCategory { get; set; }
        public virtual Store Store { get; set; }
        public virtual Client User { get; set; }
    }
}
