using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Talbat.Models
{
    public partial class Offer
    {
        public Offer()
        {
            ClientOffers = new HashSet<ClientOffer>();
            OfferItems = new HashSet<OfferItem>();
        }

        [Key]
        public int OfferId { get; set; }

        [Required]
        public string OfferImage { get; set; }

        [Required]
        public string OfferName { get; set; }

        [Required]
        [Range(0, 1)]
        public int OfferTypeIsCoupon { get; set; }

        [Required]
        [MaxLength(500)]
        public string OfferDescription { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        public DateTime OfferStartDate { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int OfferQuantity { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int OfferDaysNumber { get; set; }

        [Required]
        [Range(0, 1)]
        public int OfferItemTypePercentage { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int OfferItemSaleValue { get; set; }

        public virtual ICollection<ClientOffer> ClientOffers { get; set; }
        public virtual ICollection<OfferItem> OfferItems { get; set; }
    }
}
