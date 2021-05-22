using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int OfferId { get; set; }
        public string OfferImage { get; set; }
        public string OfferName { get; set; }
        [Range(0, 1, ErrorMessage = "OfferType Must be between 0 or 1")]
        public int OfferTypeIsCoupon { get; set; }
        public string OfferDescription { get; set; }
        public DateTime OfferStartDate { get; set; }
        public int OfferQuantity { get; set; }
        public int OfferDaysNumber { get; set; }
        public string OfferPrice { get; set; }


        [ForeignKey("store")]
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<ClientOffer> ClientOffers { get; set; }
        public virtual ICollection<OfferItem> OfferItems { get; set; }
    }
}
