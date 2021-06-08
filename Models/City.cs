using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("City")]
    public partial class City
    {
        public City()
        {
            //ClientAddresses = new HashSet<ClientAddress>();
        }

        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "CityName is required")]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string CityName { get; set; }


        [InverseProperty(nameof(ClientAddress.City))]
        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }
    }
}
