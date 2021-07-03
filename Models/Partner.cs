using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("Partner")]
    [Index(nameof(StoreId), Name = "IX_Partner_Store_Id")]
    public partial class Partner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartnerId { get; set; }

        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 3)]
        public string PartnerFname { get; set; }

        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 3)]
        public string PartnerLname { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$")]
        public string PartnerEmail { get; set; }

        [Required]
        public int PartnerPhoneNo { get; set; }

        [Required]
        public int StoreId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 100, MinimumLength = 8)]

        //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$")]


        public string PartnerPassword { get; set; }

        public DateTime JoinDate { get; set; }

        [ForeignKey(nameof(StoreId))]
        [InverseProperty("Partners")]
        public virtual Store Store { get; set; }

    }
}
