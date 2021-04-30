using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public string ReviewContent { get; set; }
        public DateTime? ReviewDate { get; set; }
        public double? ReviewRates { get; set; }
        public int? ReviewCategoryId { get; set; }
        public int? UserId { get; set; }
        public int? StoreId { get; set; }

        public virtual ReviewCategory ReviewCategory { get; set; }
        public virtual Store Store { get; set; }
        public virtual Client User { get; set; }
    }
}
