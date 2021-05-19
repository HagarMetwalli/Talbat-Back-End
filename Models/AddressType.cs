using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class AddressType
    {
        public AddressType()
        {
            ClientAddresses = new HashSet<ClientAddress>();
        }

        public int AddressTypeId { get; set; }
        public string AddressTypeName { get; set; }

        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }
    }
}
