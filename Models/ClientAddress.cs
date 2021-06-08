using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    [Table("ClientAddress")]
    [Index(nameof(CityId), Name = "IX_ClientAddress_City_Id")]
    [Index(nameof(ClientAddressTypeId), Name = "IX_ClientAddress_ClientAddress_Type_Id")]
    [Index(nameof(ClientId), Name = "IX_ClientAddress_Client_Id")]
    [Index(nameof(RegionId), Name = "IX_ClientAddress_Region_Id")]
    public partial class ClientAddress
    {
        public ClientAddress()
        {
            //ClientDeliveryManOrders = new HashSet<ClientDeliveryManOrder>();
        }

        [Key]
        public int ClientAddressId { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 10)]
        public string ClientAddressMobileNumber { get; set; }

        [Required]
        public int ClientAddressLandLine { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string ClientAddressAddressTitle { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string ClientAddressStreet { get; set; }

        [Required]
        public int ClientAddressBuilding { get; set; }

        [Required]
        public int ClientAddressFloor { get; set; }

        [Required]
        public int ClientAddressApartmentNumber { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 3)]
        [DefaultValue("")]
        public string ClientAddressOptionalDirections { get; set; }

        [Required]
        [ForeignKey("ClientAddressType")]
        public int ClientAddressTypeId { get; set; }

        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }

        [Required]
        [ForeignKey("Region")]
        public int RegionId { get; set; }

        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("ClientAddresses")]
        public virtual City City { get; set; }
        [ForeignKey(nameof(ClientId))]
        [InverseProperty("ClientAddresses")]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(ClientAddressTypeId))]
        [InverseProperty(nameof(AddressType.ClientAddresses))]
        public virtual AddressType ClientAddressType { get; set; }
        [ForeignKey(nameof(RegionId))]
        [InverseProperty("ClientAddresses")]
        public virtual Region Region { get; set; }
        [InverseProperty(nameof(ClientDeliveryManOrder.ClientAddress))]
        public virtual ICollection<ClientDeliveryManOrder> ClientDeliveryManOrders { get; set; }
    }
}
