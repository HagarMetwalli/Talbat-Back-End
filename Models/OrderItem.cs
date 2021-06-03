using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class OrderItem
    {
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ItemId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int OrderItemQty { get; set; }

        [MaxLength(100)]
        public string OrderItemSpecialRequest { get; set; }

        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
