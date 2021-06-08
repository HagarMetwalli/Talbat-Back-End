using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("AddressType")]
    public partial class AddressType
    {
        public AddressType()
        {
            //ClientAddresses = new HashSet<ClientAddress>();
        }

        [Key]
        public int AddressTypeId { get; set; }

        [Required(ErrorMessage = "AddressTypeName is required")]
        [StringLength(maximumLength: 20, MinimumLength = 3)] 
        public string AddressTypeName { get; set; }


        [InverseProperty(nameof(ClientAddress.ClientAddressType))]
        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }
    }
}
