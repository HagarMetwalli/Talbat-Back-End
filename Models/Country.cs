using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("Country")]
    public partial class Country
    {
        public Country()
        {
            //Items = new HashSet<Item>();
        }

        [Key]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "CountryName is required")]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "CurrencyName is required")]
        [StringLength(maximumLength: 20, MinimumLength = 1)]
        public string CurrencyName { get; set; }


        [InverseProperty(nameof(Item.Country))]
        public virtual ICollection<Item> Items { get; set; }

        [InverseProperty(nameof(Store.Country))]
        public virtual ICollection<Store> Stores{ get; set; }

        [InverseProperty(nameof(TempPartnerRegisterationDetail.Country))]
        public virtual ICollection<TempPartnerRegisterationDetail> TempPartnerRegisterationDetails { get; set; }


    }
}
