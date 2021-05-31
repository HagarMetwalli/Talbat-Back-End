using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Key]
        public int OrderId { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double OrderCost { get; set; }

        [MaxLength(100)]
        public string OrderSpecialRequest { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //[Range(typeof(DateTime), "1/1/2021", "12/12/2021")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderTime { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ClientId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int StoreId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<OrderReview> OrderReviews { get; set; }
    }
}
