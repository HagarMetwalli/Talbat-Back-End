//using System;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//#nullable disable

//namespace Talbat.Models
//{
//    [Table("SystemReview")]
//    public partial class SystemReview
//    {

//        [Key]
//        public int SystemReviewId { get; set; }

//        [Required]
//        [Range(1, 10), DefaultValue(1)]
//        public int RateTalabatExperience { get; set; }

//        [Required]
//        [Range(1, 10), DefaultValue(1)]
//        public int EffortMadeToOrderFood { get; set; }

//        [Required]
//        [Range(1, 10), DefaultValue(1)]
//        public int RecommendToFriend { get; set; }

//        [Required]
//        [StringLength(maximumLength: 200, MinimumLength = 1)]
//        [DefaultValue("")]
//        public string SystemReviewComment { get; set; }

//        [Required]
//        public int ClientId { get; set; }


//        [ForeignKey(nameof(ClientId))]
//        [InverseProperty("OrderReviews")]
//        public virtual Client Client { get; set; }

//    }
//}
