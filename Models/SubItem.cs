using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class SubItem
    {
        public int SubItemId { get; set; }
        public string SubItemName { get; set; }
        public double SubItemPrice { get; set; }
        public byte[] SubItemSelectionType { get; set; }
        public int SubItemCategoryId { get; set; }
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
        public virtual SubItemCategory SubItemCategory { get; set; }
    }
}
