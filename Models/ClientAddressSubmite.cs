using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Talbat.Models
{
    [NotMapped]
    public class ClientAddressSubmite
    {
      
        public int ClientAddressId { get; set; }

        public string ClientAddressMobileNumber { get; set; }

        public int ClientAddressLandLine { get; set; }

        public string ClientAddressAddressTitle { get; set; }

        public string ClientAddressStreet { get; set; }

        public int ClientAddressBuilding { get; set; }

        public int ClientAddressFloor { get; set; }

        public int ClientAddressApartmentNumber { get; set; }

        public string ClientAddressOptionalDirections { get; set; }

        public int ClientAddressTypeId { get; set; }

        //was id
        public string CityName { get; set; }

        //was id
        public string RegionName { get; set; }

        public int ClientId { get; set; }
    }
}
