using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class SubItemCategory
    {
        public SubItemCategory()
        {
            SubItems = new HashSet<SubItem>();
        }

        public int SubItemCategoryId { get; set; }
        public string SubItemCategoryName { get; set; }
        public string SubItemCategoryDescription { get; set; }

        public virtual ICollection<SubItem> SubItems { get; set; }
    }
}
