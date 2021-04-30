using System;
using System.Collections.Generic;

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
        public string OfferType { get; set; }
        public string OfferDescription { get; set; }
        public DateTime OfferStartDate { get; set; }
        public int OfferQuantity { get; set; }
        public int OfferDaysNumber { get; set; }
        public string OfferPrice { get; set; }

        public virtual ICollection<ClientOffer> ClientOffers { get; set; }
        public virtual ICollection<OfferItem> OfferItems { get; set; }
    }
}
