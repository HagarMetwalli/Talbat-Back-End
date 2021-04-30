using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            ClientDeliveryManOrders = new HashSet<ClientDeliveryManOrder>();
        }

        public int InvoiceId { get; set; }
        public double? Price { get; set; }
        public string AddressDetails { get; set; }
        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<ClientDeliveryManOrder> ClientDeliveryManOrders { get; set; }
    }
}
