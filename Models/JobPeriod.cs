using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("JobPeriod")]
    public partial class JobPeriod
    {
        public JobPeriod()
        {
            //Jobs = new HashSet<Job>();
        }

        [Key]
        public int JobPeriodId { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string JobPeriodName { get; set; }


        [InverseProperty(nameof(Job.JobPeriod))]
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
