using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("JobType")]
    public partial class JobType
    {
        public JobType()
        {
            //Jobs = new HashSet<Job>();
        }

        [Key]
        public int JobTypeId { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string JobTypeName { get; set; }


        [InverseProperty(nameof(Job.JobType))]
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
