using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class Cuisine
    {
        public Cuisine()
        {
            //Stores = new HashSet<Store>();
        }

        [Key]
        public int CuisineId { get; set; }

        [Required(ErrorMessage = "CuisineName is required")]
        [StringLength(maximumLength: 40, MinimumLength = 3)]
        public string CuisineName { get; set; }

        [Required]
        [Range(0, int.MaxValue), DefaultValue(0)]
        public int TotalOrdersNumber { get; set; }


        [InverseProperty(nameof(Store.Cuisine))]
        public virtual ICollection<Store> Stores { get; set; }
    }
}
