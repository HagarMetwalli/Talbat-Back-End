using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class TempPartnerRegisterationDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TempPartnerStoreId { get; set; }

        [Required]
        [MaxLength(50), MinLength(3)]
        public string PartnerFname { get; set; }

        [Required]
        [MaxLength(50), MinLength(3)]
        public string PartnerLname { get; set; }

        [Required]
        [MaxLength(100), MinLength(3)]
        public string StoreCountry { get; set; }

        [Required]
        [RegularExpression("^\\+?\\d{0,3}\\s?\\(?\\d{3}\\)?[-.\\s]?\\d{3}[-.\\s]?\\d{4}$")]
        public string PartnerPhoneNumber { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$")]
        public string PartnerEmail { get; set; }

        [Required]
        public string PartnerContactRole { get; set; }

        [Required]
        [MaxLength(100), MinLength(3)]
        public string StoreName { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StoreBranchesNo { get; set; }

        [Required]
        public string StoreContact { get; set; }

        [Required]
        public int StoreAddress { get; set; }

        [Required]
        //[Range(0, int.MaxValue)]
        public byte[] StoreStatus { get; set; }

        [ForeignKey("StoreType")]
        public int StoreTypeId { get; set; }

        public virtual StoreType StoreType { get; set; }
    }
}
