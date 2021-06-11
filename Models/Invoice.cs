//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

//#nullable disable

//namespace Talbat.Models
//{
//    [Table("Invoice")]
//    [Index(nameof(OrderId), Name = "IX_Invoice_Order_Id")]
//    public partial class Invoice
//    {
//        public Invoice()
//        {
//            //ClientDeliveryManOrders = new HashSet<ClientDeliveryManOrder>();
//        }

//        [Key]
//        public int InvoiceId { get; set; }

//        [Required(ErrorMessage = "Order Price is required")]
//        public double Price { get; set; }

//        [Required(ErrorMessage = "AddressDetails is required")]
//        [MaxLength(150, ErrorMessage = "You exceeded Max. Length")]
//        public string AddressDetails { get; set; }

//        [Required(ErrorMessage = "OrderId is required")]
//        public int OrderId { get; set; }


//        [ForeignKey(nameof(OrderId))]
//        [InverseProperty("Invoices")]
//        public virtual Order Order { get; set; }

//        [InverseProperty(nameof(ClientDeliveryManOrder.Invoice))]
//        public virtual ICollection<ClientDeliveryManOrder> ClientDeliveryManOrders { get; set; }
//    }
//}
