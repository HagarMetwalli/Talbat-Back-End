using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Talbat.Models
{
    public partial class Region
    {
        public Region()
        {
            //ClientAddresses = new HashSet<ClientAddress>();
        }

        public int RegionId { get; set; }

        [Required]
        public string RegionName { get; set; }

        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }
    }
}
