using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class Item
    {
        public Item()
        {
            OfferItems = new HashSet<OfferItem>();
            OrderItems = new HashSet<OrderItem>();
            SubItems = new HashSet<SubItem>();
        }

        public int ItemId { get; set; }
        public string ItemImage { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemPrice { get; set; }
        public int ItemCategoryId { get; set; }
        public int CountryId { get; set; }
        public int StoreId { get; set; }

        public virtual Country Country { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OfferItem> OfferItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<SubItem> SubItems { get; set; }
    }
}
