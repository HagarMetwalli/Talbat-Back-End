using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Talbat.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientAddresses = new HashSet<ClientAddress>();
            ClientDeliveryManOrders = new HashSet<ClientDeliveryManOrder>();
            ClientOffers = new HashSet<ClientOffer>();
            ClientSeekingJobs = new HashSet<ClientSeekingJob>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
        }
        
        public int ClientId { get; set; }
        public string ClientFname { get; set; }
        public string ClientLname { get; set; }
        public string ClientEmail { get; set; }
        public DateTime ClientDateOfBirth { get; set; }
        public string ClientPassword { get; set; }
        [Range(0, 1, ErrorMessage = "Gender Must be between 0 or 1")]

        public int ClientGenderIsMale { get; set; }
        public int ClientNewsletterSubscribe { get; set; }
        public int ClientSmsSubscribe { get; set; }

        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }
        public virtual ICollection<ClientDeliveryManOrder> ClientDeliveryManOrders { get; set; }
        public virtual ICollection<ClientOffer> ClientOffers { get; set; }
        public virtual ICollection<ClientSeekingJob> ClientSeekingJobs { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
