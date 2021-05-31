using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Talbat.Models
{
    public partial class JobLocation
    {
        public JobLocation()
        {
            Jobs = new HashSet<Job>();
        }

        [Key]
        public int JobLocationId { get; set; }

        [Required]
        [MaxLength(50)]
        public string JobLocationName { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
