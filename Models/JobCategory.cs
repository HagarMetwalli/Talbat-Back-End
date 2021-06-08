using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("JobCategory")]
    public partial class JobCategory
    {
        public JobCategory()
        {
            //Jobs = new HashSet<Job>();
        }

        [Key]
        public int JobCategoryId { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string JobCategoryType { get; set; }


        [InverseProperty(nameof(Job.JobCategory))]
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
