using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    [Table("PromotionItem")]
    [Index(nameof(ItemId), Name = "IX_OfferItem_Item_Id")]
    public partial class PromotionItem
    {
        [Key]
        public int PromotionId { get; set; }

        [Key]
        public int ItemId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PromotionItemQuantity { get; set; }


        [ForeignKey(nameof(ItemId))]
        [InverseProperty("PromotionItems")]
        public virtual Item Item { get; set; }

        [ForeignKey(nameof(PromotionId))]
        [InverseProperty("PromotionItems")]
        public virtual Promotion Promotion { get; set; }

    }
}
