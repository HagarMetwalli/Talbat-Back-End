using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Talbat.Models
{
    public partial class JobCategory
    {
        public JobCategory()
        {
            Jobs = new HashSet<Job>();
        }

        [Key]
        public int JobCategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string JobCategoryType { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
