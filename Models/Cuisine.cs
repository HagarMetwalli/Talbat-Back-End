using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Talbat.Models
{
    public class Cuisine
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CuisineId { get; set; }

        [Required(ErrorMessage = "CuisineName is required")]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string CuisineName { get; set; }

        [Range(1,int.MaxValue), DefaultValue(0)]
        public int TotalOrdersNumber { get; set; }

    }
}
