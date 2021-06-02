using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Talbat.Models
{
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
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string CurrencyName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
