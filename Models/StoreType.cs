using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("StoreType")]
    public partial class StoreType
    {
        public StoreType()
        {
            Stores = new HashSet<Store>();
            //TempPartnerRegisterationDetails = new HashSet<TempPartnerRegisterationDetail>();
        }

        [Key]
        public int StoreTypeId { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string StoreTypeName { get; set; }


        [InverseProperty(nameof(Store.StoreType))]
        public virtual ICollection<Store> Stores { get; set; }

        [InverseProperty(nameof(TempPartnerRegisterationDetail.StoreType))]
        public virtual ICollection<TempPartnerRegisterationDetail> TempPartnerRegisterationDetails { get; set; }

    }
}
