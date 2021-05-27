using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [StringLength(maximumLength:20, MinimumLength = 3)]
        public string AddressTypeName { get; set; }

        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }
    }
}
