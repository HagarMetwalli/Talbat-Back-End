﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class OfferItem
    {
        [Key]
        [Column(Order = 1)]
        public int OfferId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ItemId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int OfferItemQuantity { get; set; }

        [Required]
        [Range(0, 1)]
        public int OfferItemTypePercentage { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int OfferItemSaleValue { get; set; }

        public virtual Item Item { get; set; }
        public virtual Offer Offer { get; set; }
    }
}
