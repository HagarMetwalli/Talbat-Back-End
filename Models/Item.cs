using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    [Table("Item")]
    [Index(nameof(CountryId), Name = "IX_Item_Country_Id")]
    [Index(nameof(StoreId), Name = "IX_Item_Store_Id")]
    public partial class Item
    {
        public Item()
        {
            //CouponItems = new HashSet<CouponItem>();
            //OrderItems = new HashSet<OrderItem>();
            //PromotionItems = new HashSet<PromotionItem>();
            //SubItems = new HashSet<SubItem>();
        }

        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Item Image is required")]
        public string ItemImage { get; set; }

        [Required(ErrorMessage = "Item Name is required")]
        [MinLength(3), MaxLength(50)]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Item Description is required")]
        [MinLength(3), MaxLength(150)]
        public string ItemDescription { get; set; }

        [Required(ErrorMessage = "Item Price is required")]
        [Range(1, int.MaxValue)]
        public int ItemPrice { get; set; }

        [Required]
        public int ItemCategoryId { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int StoreId { get; set; }


        [ForeignKey(nameof(ItemCategoryId))]
        [InverseProperty("Items")]
        public virtual ItemCategory ItemCategory { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Items")]
        public virtual Country Country { get; set; }

        [ForeignKey(nameof(StoreId))]
        [InverseProperty("Items")]
        public virtual Store Store { get; set; }

        [InverseProperty(nameof(CouponItem.Item))]
        public virtual ICollection<CouponItem> CouponItems { get; set; }

        [InverseProperty(nameof(OrderItem.Item))]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [InverseProperty(nameof(PromotionItem.Item))]
        public virtual ICollection<PromotionItem> PromotionItems { get; set; }

        [InverseProperty(nameof(SubItem.Item))]
        public virtual ICollection<SubItem> SubItems { get; set; }

        [InverseProperty(nameof(ItemReview.Item))]
        public virtual ICollection<ItemReview> ItemReviews { get; set; }
    }
}
