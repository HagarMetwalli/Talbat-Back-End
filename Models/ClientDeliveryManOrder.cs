using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    [Table("ClientDeliveryManOrder")]
    [Index(nameof(ClientAddressId), Name = "IX_ClientDeliveryManOrder_ClientAddress_Id")]
    [Index(nameof(DeliveryManId), Name = "IX_ClientDeliveryManOrder_DeliveryMan_Id")]
    //[Index(nameof(InvoiceId), Name = "IX_ClientDeliveryManOrder_Invoice_Id")]
    public partial class ClientDeliveryManOrder
    {
        [Key]
        public int ClientId { get; set; }

        [Key]
        public int DeliveryManId { get; set; }

        //[Key]
        //public int InvoiceId { get; set; }

        [Required]
        public int ClientAddressId { get; set; }

        [Required]
        public DateTime OrderShipingTime { get; set; }


        [ForeignKey(nameof(ClientId))]
        [InverseProperty("ClientDeliveryManOrders")]
        public virtual Client Client { get; set; }

        [ForeignKey(nameof(ClientAddressId))]
        [InverseProperty("ClientDeliveryManOrders")]
        public virtual ClientAddress ClientAddress { get; set; }

        [ForeignKey(nameof(DeliveryManId))]
        [InverseProperty("ClientDeliveryManOrders")]
        public virtual DeliveryMan DeliveryMan { get; set; }

        //[ForeignKey(nameof(InvoiceId))]
        //[InverseProperty("ClientDeliveryManOrders")]
        //public virtual Invoice Invoice { get; set; }
    }
}
