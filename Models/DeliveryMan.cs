using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("DeliveryMan")]
    public partial class DeliveryMan
    {
        public DeliveryMan()
        {
            //ClientDeliveryManOrders = new HashSet<ClientDeliveryManOrder>();
        }

        [Key]
        public int DeliveryManId { get; set; }

        [Required(ErrorMessage = "DeliveryManName is required")]
        [StringLength(maximumLength: 40, MinimumLength = 3)]
        public string DeliveryManName { get; set; }

        [Required]
        public int DeliveryManSalary { get; set; }

        [Required]
        public DateTime DeliveryManHireDate { get; set; }

        [Required(ErrorMessage = "DeliveryManCurrentLocation is required")]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string DeliveryManCurrentLocation { get; set; }


        [InverseProperty(nameof(ClientDeliveryManOrder.DeliveryMan))]
        public virtual ICollection<ClientDeliveryManOrder> ClientDeliveryManOrders { get; set; }
    }
}
