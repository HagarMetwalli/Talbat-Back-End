using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    [Table("Store")]
    [Index(nameof(CuisineId), Name = "IX_Store_CuisineId")]
    [Index(nameof(StoreTypeId), Name = "IX_Store_StoreType_Id")]
    public partial class Store
    {
        public Store()
        {
            //Coupons = new HashSet<Coupon>();
           // Items = new HashSet<Item>();
            //Orders = new HashSet<Order>();
            //Partners = new HashSet<Partner>();
            //Reviews = new HashSet<Review>();
            //StoreWorkingHours = new HashSet<StoreWorkingHour>();
        }

        [Key]
        public int StoreId { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string StoreName { get; set; }

        [Required]
        [StringLength(maximumLength: 400, MinimumLength = 1)]
        public string StoreDescription { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        [StringLength(maximumLength: 200, MinimumLength = 1)]
        public string StoreAddress { get; set; }

        [Required, DefaultValue(0.000000)]
        //[RegularExpression("^-/+?[0-9]{9}.[0-9]{9}$", ErrorMessage ="Invalid Latitude")]
        public double StoreLatitude { get; set; }

        [Required, DefaultValue(0.000000)]
        //[RegularExpression("^-/+?[0-9]{9}.[0-9]{9}$", ErrorMessage = "Invalid Longitude")]
        public double StoreLongitude { get; set; }

        [Required]
        [DefaultValue(1)]
        public double StoreDeliveryDistance { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double StoreMinOrder { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StoreDeliveryTime { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double StoreDeliveryFee { get; set; }

        [Required]
        [Range(0, 1), DefaultValue(0)]
        public string StorePreOrder { get; set; }

        [Required]
        [Range(0, 1), DefaultValue(1)]
        public int StorePaymentOnDeliverCash { get; set; }

        [Required]
        [Range(0, 1), DefaultValue(0)]
        public int StorePaymentVisa { get; set; }

        [Required]
        public int StoreTypeId { get; set; }

        [Required]
        public int CuisineId { get; set; }

        [Required]
        [Range(0, int.MaxValue), DefaultValue(0)]
        public int StoreOrdersNumber { get; set; }


        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Stores")]
        public virtual Country Country { get; set; }

        [ForeignKey(nameof(StoreTypeId))]
        [InverseProperty("Stores")]
        public virtual StoreType StoreType { get; set; }

        [ForeignKey(nameof(CuisineId))]
        [InverseProperty("Stores")]
        public virtual Cuisine Cuisine { get; set; }

        [InverseProperty(nameof(Coupon.Store))]
        public virtual ICollection<Coupon> Coupons { get; set; }

        [InverseProperty(nameof(Item.Store))]
        public virtual ICollection<Item> Items { get; set; }

        [InverseProperty(nameof(Order.Store))]
        public virtual ICollection<Order> Orders { get; set; }

        [InverseProperty(nameof(Partner.Store))]
        public virtual ICollection<Partner> Partners { get; set; }

        [InverseProperty(nameof(StoreWorkingHour.Store))]
        public virtual ICollection<StoreWorkingHour> StoreWorkingHours { get; set; }

    
      

    }
}
