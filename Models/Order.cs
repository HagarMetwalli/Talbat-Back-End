using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class Order
    {
        public Order()
        {
            Invoices = new HashSet<Invoice>();
            OrderItems = new HashSet<OrderItem>();
            OrderReviews = new HashSet<OrderReview>();
        }

        public int OrderId { get; set; }
        public double OrderCost { get; set; }
        public string OrderSpecialRequest { get; set; }
        public DateTime? OrderTime { get; set; }
        public int ClientId { get; set; }
        public int StoreId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<OrderReview> OrderReviews { get; set; }
    }
}
