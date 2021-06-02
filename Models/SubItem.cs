using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class SubItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SubItemId { get; set; }

        [MaxLength(100), MinLength(1)]
        [Required]
        public string SubItemName { get; set; }

        [Range(1, int.MaxValue)]
        [Required]
        public double SubItemPrice { get; set; }

        [Range(0,1)]
        [Required]
        public int SubItemSelectionType { get; set; }

        [ForeignKey("SubItemCategory")]
        public int SubItemCategoryId { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
        public virtual SubItemCategory SubItemCategory { get; set; }
    }
}
