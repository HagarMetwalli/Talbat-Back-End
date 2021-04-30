using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class Country
    {
        public Country()
        {
            Items = new HashSet<Item>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CurrencyName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
