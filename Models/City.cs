using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class City
    {
        public City()
        {
            ClientAddresses = new HashSet<ClientAddress>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }
    }
}
