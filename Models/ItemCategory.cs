using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Talbat.Models
{
    public partial class ItemCategory
    {
        [Key]
        public int ItemCategoryId { get; set; }

        [Required(ErrorMessage = "ItemCategoryName is required")]
        [MinLength(3), MaxLength(20)]
        public string ItemCategoryName { get; set; }
    }
}
