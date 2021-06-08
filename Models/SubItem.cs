using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    [Table("SubItem")]
    [Index(nameof(ItemId), Name = "IX_SubItem_Item_Id")]
    [Index(nameof(SubItemCategoryId), Name = "IX_SubItem_SubItemCategory_Id")]
    public partial class SubItem
    {
        [Key]
        public int SubItemId { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 1)]
        public string SubItemName { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public double SubItemPrice { get; set; }

        [Required]
        [Range(0, 1), DefaultValue(1)]
        public int SubItemIsRadioButton { get; set; }

        [Required]
        public int SubItemCategoryId { get; set; }

        [Required]
        public int ItemId { get; set; }


        [ForeignKey(nameof(ItemId))]
        [InverseProperty("SubItems")]
        public virtual Item Item { get; set; }

        [ForeignKey(nameof(SubItemCategoryId))]
        [InverseProperty("SubItems")]
        public virtual SubItemCategory SubItemCategory { get; set; }

    }
}
