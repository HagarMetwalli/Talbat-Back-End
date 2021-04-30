using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class OrderItem
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int OrderItemQty { get; set; }
        public string OrderItemSpecialRequest { get; set; }

        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
