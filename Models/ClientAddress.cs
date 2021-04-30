using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class ClientAddress
    {
        public ClientAddress()
        {
            ClientDeliveryManOrders = new HashSet<ClientDeliveryManOrder>();
        }

        public int ClientAddressId { get; set; }
        public string ClientAddressMobileNumber { get; set; }
        public string ClientAddressLandLine { get; set; }
        public string ClientAddressAddressTitle { get; set; }
        public string ClientAddressType { get; set; }
        public string ClientAddressStreet { get; set; }
        public string ClientAddressBuilding { get; set; }
        public string ClientAddressFloor { get; set; }
        public int ClientAddressApartmentNumber { get; set; }
        public string ClientAddressOptionalDirections { get; set; }
        public int CityId { get; set; }
        public int RegionId { get; set; }
        public int ClientId { get; set; }

        public virtual City City { get; set; }
        public virtual Client Client { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<ClientDeliveryManOrder> ClientDeliveryManOrders { get; set; }
    }
}
