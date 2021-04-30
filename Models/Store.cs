using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class Store
    {
        public Store()
        {
            Items = new HashSet<Item>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
            StoreWorkingHours = new HashSet<StoreWorkingHour>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreDescription { get; set; }
        public int CountryId { get; set; }
        public string StoreAddress { get; set; }
        public double? StoreMinOrder { get; set; }
        public int StoreDeliveryTime { get; set; }
        public double? StoreDeliveryFee { get; set; }
        public string StorePreOrder { get; set; }
        public int? StorePaymentOnDeliverCash { get; set; }
        public int? StorePaymentVisa { get; set; }
        public string StoreCuisine { get; set; }
        public int? StoreRate { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<StoreWorkingHour> StoreWorkingHours { get; set; }
    }
}
