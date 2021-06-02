using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Talbat.Models
{
    public partial class DeliveryMan
    {
        public DeliveryMan()
        {
           // ClientDeliveryManOrders = new HashSet<ClientDeliveryManOrder>();
        }
        [Key]
        public int DeliveryManId { get; set; }

        [Required(ErrorMessage = "DeliveryManName is required")]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string DeliveryManName { get; set; }

        [DefaultValue(0)]
        public int? DeliveryManSalary { get; set; }
        public DateTime? DeliveryManHireDate { get; set; }

        [Required(ErrorMessage = "DeliveryManCurrentLocation is required")]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string DeliveryManCurrentLocation { get; set; }

        public virtual ICollection<ClientDeliveryManOrder> ClientDeliveryManOrders { get; set; }
    }
}
