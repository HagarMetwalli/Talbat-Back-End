using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class Partner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PartnerId { get; set; }
        [MaxLength(10), MinLength(3)]
        [Required]
        public string PartnerFname { get; set; }

        [MaxLength(10), MinLength(3)]
        [Required]
        public string PartnerLname { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$")]
        public string PartnerEmail { get; set; }

        [Required]
        //[RegularExpression("^\\+?\\d{0,3}\\s?\\(?\\d{3}\\)?[-.\\s]?\\d{3}[-.\\s]?\\d{4}$")]
        public int PartnerPhoneNo { get; set; }

        [Required]
        [ForeignKey("Store")]
        public int? StoreId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(100), MinLength(8)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$")]
        public string PartnerPassword { get; set; }

        public virtual Store Store { get; set; }
    }
}
