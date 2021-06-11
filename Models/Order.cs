using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{

    public enum DeliveryStatus
    {
        InKitchen,
        ReadyForDeliver,
        InWay,
        Delivered
    }

    [Table("Order")]
    [Index(nameof(ClientId), Name = "IX_Order_Client_Id")]
    [Index(nameof(StoreId), Name = "IX_Order_Store_Id")]
    public partial class Order
    {
        public Order()
        {
            //Invoices = new HashSet<Invoice>();
            //OrderItems = new HashSet<OrderItem>();
            //OrderReviews = new HashSet<OrderReview>();
        }

        [Key]
        public int OrderId { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double OrderCost { get; set; }

        [Required]
        [StringLength(maximumLength: 200, MinimumLength = 1)]
        public string OrderSpecialRequest { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }

        [Required(ErrorMessage = "AddressDetails is required")]
        [MaxLength(150, ErrorMessage = "You exceeded Max. Length")]
        public string AddressDetails { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int StoreId { get; set; }

        [Required]
        public DeliveryStatus IsDelivered { get; set; }


        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Orders")]
        public virtual Client Client { get; set; }

        [ForeignKey(nameof(StoreId))]
        [InverseProperty("Orders")]
        public virtual Store Store { get; set; }

        //[InverseProperty(nameof(Invoice.Order))]
        //public virtual ICollection<Invoice> Invoices { get; set; }

        [InverseProperty(nameof(OrderItem.Order))]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [InverseProperty(nameof(OrderReview.Order))]
        public virtual ICollection<OrderReview> OrderReviews { get; set; }

    }
}


// TODO: ||Done|| Add Order Delivery Address, OrderDelivery Status