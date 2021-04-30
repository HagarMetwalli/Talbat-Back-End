using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class ClientDeliveryManOrder
    {
        public int ClientId { get; set; }
        public int DeliveryManId { get; set; }
        public int InvoiceId { get; set; }
        public int ClientAddressId { get; set; }
        public DateTime? OrderShipingTime { get; set; }

        public virtual Client Client { get; set; }
        public virtual ClientAddress ClientAddress { get; set; }
        public virtual DeliveryMan DeliveryMan { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
