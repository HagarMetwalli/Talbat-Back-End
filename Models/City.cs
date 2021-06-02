using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Talbat.Models
{
    public partial class City
    {
        public City()
        {
           // ClientAddresses = new HashSet<ClientAddress>();
        }

        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "CityName is required")]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string CityName { get; set; }

        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }
    }
}
