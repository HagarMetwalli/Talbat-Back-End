using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("Client")]
    public partial class Client
    {
        public Client()
        {
            //ClientAddresses = new HashSet<ClientAddress>();
            //ClientDeliveryManOrders = new HashSet<ClientDeliveryManOrder>();
            //ClientOffers = new HashSet<ClientOffer>();
            //ClientSeekingJobs = new HashSet<ClientSeekingJob>();
            //OrderReviews = new HashSet<OrderReview>();
            //Orders = new HashSet<Order>();
            //Reviews = new HashSet<Review>();
        }

        [Key]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "FristName is required")]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Invalid fristname format only alphabetic characters is accepted")]
        public string ClientFname { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Invalid lastname format only alphabetic characters is accepted")]
        public string ClientLname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string ClientEmail { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ClientDateOfBirth { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string ClientPassword { get; set; }

        [Required(ErrorMessage = "Gender Is Required")]
        [Range(0, 1, ErrorMessage = "Gender Must be Male = 0 or Female = 1 ")]
        public int ClientGenderIsMale { get; set; }

        [Required, DefaultValue(0)]
        [Range(0, 1, ErrorMessage = "ClientNewsletterSubscribe Must be False = 0 or true = 1 ")]
        public int ClientNewsletterSubscribe { get; set; }

        [Required, DefaultValue(0)]
        [Range(0, 1, ErrorMessage = "ClientSmsSubscribe Must be False = 0 or true = 1 ")]
        public int ClientSmsSubscribe { get; set; }


        [InverseProperty(nameof(ClientAddress.Client))]
        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }

        [InverseProperty(nameof(ClientDeliveryManOrder.Client))]
        public virtual ICollection<ClientDeliveryManOrder> ClientDeliveryManOrders { get; set; }

        [InverseProperty(nameof(ClientPromotion.Client))]
        public virtual ICollection<ClientPromotion> ClientPromotions { get; set; }
        
        [InverseProperty(nameof(ClientCoupon.Client))]
        public virtual ICollection<ClientCoupon> ClientCoupons { get; set; }

        [InverseProperty(nameof(ClientSeekingJob.Client))]
        public virtual ICollection<ClientSeekingJob> ClientSeekingJobs { get; set; }

        [InverseProperty(nameof(OrderReview.Client))]
        public virtual ICollection<OrderReview> OrderReviews { get; set; }

        [InverseProperty(nameof(Order.Client))]
        public virtual ICollection<Order> Orders { get; set; }

        [InverseProperty(nameof(SystemReview.Client))]
        public virtual ICollection<SystemReview> SystemReviews { get; set; }


    }
}
