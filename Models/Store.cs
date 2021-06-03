using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

#nullable disable

namespace Talbat.Models
{
    public partial class Store
    {
        public Store()
        {
            //    Items = new HashSet<Item>();
            //    Orders = new HashSet<Order>();
            //    Partners = new HashSet<Partner>();
            //    Reviews = new HashSet<Review>();
            //    StoreWorkingHours = new HashSet<StoreWorkingHour>();
        }

        public int StoreId { get; set; }

        [MaxLength(10), MinLength(3)]
        [Required]

        public string StoreName { get; set; }

        [MaxLength(200), MinLength(3)]
        [Required]
        public string StoreDescription { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [Required]
        public string StoreAddress { get; set; }

        [Required, DefaultValue(0.000000)]
       //[RegularExpression("^-/+?[0-9]{9}.[0-9]{9}$", ErrorMessage ="Invalid Latitude")]
        public double StoreLatitude { get; set; }

        [Required, DefaultValue(0.000000)]
        //[RegularExpression("^-/+?[0-9]{9}.[0-9]{9}$", ErrorMessage = "Invalid Longitude")]
        public double StoreLongitude { get; set; }

        [Required,DefaultValue(1)]
        public double StoreDeliveryDist { get; set; }

        [Range(0, int.MaxValue)]
        public double StoreMinOrder { get; set; }

        [Required] 
        public int StoreDeliveryTime { get; set; }

        [Range(0, int.MaxValue)]
        public double StoreDeliveryFee { get; set; }
        public string StorePreOrder { get; set; }

        [Range(0,1)]
        public int StorePaymentOnDeliverCash { get; set; }

        [Range(0,1)]
        public int StorePaymentVisa { get; set; }

        [ForeignKey("StoreType")]
        public int StoreTypeId { get; set; }

      
        [ForeignKey("Cuisine")]
        public int? CuisineId { get; set; }

        [DefaultValue(0)]
        public int StoreOrdersNumber { get; set; }
       
        public virtual StoreType StoreType { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Partner> Partners { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<StoreWorkingHour> StoreWorkingHours { get; set; }
        public virtual Cuisine Cuisine { get; set; }
        public virtual Country Country { get; set; }

    }
}
