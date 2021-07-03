using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Talbat.Models
{
    [NotMapped]
    public class OrderSubmitData
    {
        public Order order { get; set; }
        public List<OrderItem> orderItemsList { get; set; }

       // public Coupon coupon = null;

    }
}
