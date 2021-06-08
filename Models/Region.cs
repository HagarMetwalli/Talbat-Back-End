using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("Region")]
    public partial class Region
    {
        public Region()
        {
            //ClientAddresses = new HashSet<ClientAddress>();
        }

        [Key]
        public int RegionId { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string RegionName { get; set; }


        [InverseProperty(nameof(ClientAddress.Region))]
        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }

    }
}
