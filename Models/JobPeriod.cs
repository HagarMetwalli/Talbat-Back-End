using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Talbat.Models
{
    public partial class JobPeriod
    {
        public JobPeriod()
        {
            Jobs = new HashSet<Job>();
        }

        [Key]
        public int JobPeriodId { get; set; }

        [Required]
        [MaxLength(50)]
        public string JobPeriodName { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
