using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class ReviewCategory
    {
        public ReviewCategory()
        {
            Reviews = new HashSet<Review>();
        }

        public int ReviewCategoryId { get; set; }
        public string ReviewCategoryName { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
