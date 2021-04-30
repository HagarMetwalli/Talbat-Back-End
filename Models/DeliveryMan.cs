using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class DeliveryMan
    {
        public DeliveryMan()
        {
            ClientDeliveryManOrders = new HashSet<ClientDeliveryManOrder>();
        }

        public int DeliveryManId { get; set; }
        public string DeliveryManName { get; set; }
        public int? DeliveryManSalary { get; set; }
        public DateTime? DeliveryManHireDate { get; set; }
        public string DeliveryManCurrentLocation { get; set; }

        public virtual ICollection<ClientDeliveryManOrder> ClientDeliveryManOrders { get; set; }
    }
}
