using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Talbat.Models
{
    public partial class JobType
    {
        public JobType()
        {
            Jobs = new HashSet<Job>();
        }

        [Key]
        public int JobTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string JobTypeName { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
