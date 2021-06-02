using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class ClientAddress
    {
        public ClientAddress()
        {
           // ClientDeliveryManOrders = new HashSet<ClientDeliveryManOrder>();
        }
        [Key]
        public int ClientAddressId { get; set; }

        [Required, StringLength(maximumLength:20 , MinimumLength =10)]
        public string ClientAddressMobileNumber { get; set; }

        [Required, StringLength(maximumLength: 20, MinimumLength = 3)]
        public string ClientAddressLandLine { get; set; }

        [Required, StringLength(maximumLength: 20, MinimumLength = 3)]
        public string ClientAddressAddressTitle { get; set; }

        [Required, StringLength(maximumLength: 20, MinimumLength = 3)]
        public string ClientAddressStreet { get; set; }

        [Required, StringLength(maximumLength: 20, MinimumLength = 3)]
        public string ClientAddressBuilding { get; set; }

        [Required, StringLength(maximumLength: 20, MinimumLength = 3)]
        public string ClientAddressFloor { get; set; }
        [Required,MinLength(1),MaxLength(4)]
        public int ClientAddressApartmentNumber { get; set; }

        [Required, StringLength(maximumLength: 20, MinimumLength = 3)]
        public string ClientAddressOptionalDirections { get; set; }

        [Required, ForeignKey("ClientAddressType")]
        public int ClientAddressTypeId { get; set; }

        [Required, ForeignKey("City")]
        public int CityId { get; set; }

        [Required, ForeignKey("Region")]
        public int RegionId { get; set; }

        [Required,ForeignKey("Client")]
        public int ClientId { get; set; }

        public virtual City City { get; set; }
        public virtual Client Client { get; set; }
        public virtual AddressType ClientAddressType { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<ClientDeliveryManOrder> ClientDeliveryManOrders { get; set; }
    }
}
