using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
           // ClientDeliveryManOrders = new HashSet<ClientDeliveryManOrder>();
        }

        [Key]
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Order Price is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "AddressDetails is required")]
        [MaxLength(100,ErrorMessage ="You exceeded Max. Length")]
        public string AddressDetails { get; set; }

        [ForeignKey("Order")]
        [Required(ErrorMessage ="OrderId is required")]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<ClientDeliveryManOrder> ClientDeliveryManOrders { get; set; }
    }
}
