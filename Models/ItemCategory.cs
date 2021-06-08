using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("ItemCategory")]
    public partial class ItemCategory
    {
        [Key]
        public int ItemCategoryId { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string ItemCategoryName { get; set; }

        [InverseProperty(nameof(Item.ItemCategory))]
        public virtual ICollection<Item> Items { get; set; }
    }
}
