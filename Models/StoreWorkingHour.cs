using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class StoreWorkingHour
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int StoreWorkingHourId { get; set; }

        [Required]
        public string StoreWorkingHourDay { get; set; }

        [Range(0, int.MaxValue)]
        public int StoreWorkingHourStart { get; set; }

        [Range(0, int.MaxValue)]
        public int StoreWorkingHourEnd { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}
