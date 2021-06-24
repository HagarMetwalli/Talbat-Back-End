using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    [Table("OrderItem")]
    [Index(nameof(ItemId), Name = "IX_OrderItem_Item_Id")]
    public partial class OrderItem
    {
      
        [Key]
        public int OrderId { get; set; }

        [Key]
        public int ItemId { get; set; }

        [Required]
        [Range(1, int.MaxValue), DefaultValue(1)]
        public int OrderItemQty { get; set; }

       
        [StringLength(maximumLength: 200, MinimumLength = 1)]
        public string OrderItemSpecialRequest { get; set; }


        [ForeignKey(nameof(ItemId))]
        [InverseProperty("OrderItems")]
        public virtual Item Item { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderItems")]
        public virtual Order Order { get; set; }

       

    }
}
