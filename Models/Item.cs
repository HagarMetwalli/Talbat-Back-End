using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class Item
    {
        public Item()
        {
            //OfferItems = new HashSet<OfferItem>();
            //OrderItems = new HashSet<OrderItem>();
            //SubItems = new HashSet<SubItem>();
        }
        [Key]
        public int ItemId { get; set; }
        [Required(ErrorMessage ="Item Image is required")]
        public string ItemImage { get; set; }

        [Required(ErrorMessage = "Item Name is required")]
        [MinLength(3),MaxLength(50)]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Item Description is required")]
        [MinLength(3), MaxLength(150)]
        public string ItemDescription { get; set; }

        [Required(ErrorMessage = "Item Price is required")]
        [MinLength(3), MaxLength(20),DefaultValue(0)]
        public string ItemPrice { get; set; }

        [Required ,ForeignKey("ItemCategory")]
        public int ItemCategoryId { get; set; }

        [Required,ForeignKey("Country")]
        public int CountryId { get; set; }

        [Required,ForeignKey("Store")]
        public int StoreId { get; set; }

        public virtual ItemCategory ItemCategory { get; set; }
        public virtual Country Country { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OfferItem> OfferItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<SubItem> SubItems { get; set; }
    }
}
