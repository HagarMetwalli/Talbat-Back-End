using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    [Index(nameof(StoreTypeId), Name = "IX_TempPartnerRegisterationDetails_Store_Type_Id")]
    public partial class TempPartnerRegisterationDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TempPartnerStoreId { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 1)]
        public string PartnerFname { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 1)]
        public string PartnerLname { get; set; }

        [Required]
        public int StoreCountryId { get; set; }

        [Required]
        public int PartnerPhoneNumber { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$")]
        public string PartnerEmail { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 1)]
        public string PartnerContactRole { get; set; }
        //TODO: enum 

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string StoreName { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int StoreBranchesNo { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string StoreWebSite { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string StoreAddress { get; set; }


        [Required]
        public int StoreTypeId { get; set; }


        [ForeignKey(nameof(StoreTypeId))]
        [InverseProperty("TempPartnerRegisterationDetails")]
        public virtual StoreType StoreType { get; set; }
        
        [ForeignKey(nameof(StoreCountryId))]
        [InverseProperty("TempPartnerRegisterationDetails")]
        public virtual Country Country { get; set; }

    }
}
