using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class OfferItem
    {
        public int OfferId { get; set; }
        public int ItemId { get; set; }
        public int OfferItemQuantity { get; set; }
        public bool? OfferItemTypePercentage { get; set; }
        public double? OfferItemSaleValue { get; set; }

        public virtual Item Item { get; set; }
        public virtual Offer Offer { get; set; }
    }
}
