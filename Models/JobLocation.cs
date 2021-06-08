using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("JobLocation")]
    public partial class JobLocation
    {
        public JobLocation()
        {
            Jobs = new HashSet<Job>();
        }

        [Key]
        public int JobLocationId { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string JobLocationName { get; set; }


        [InverseProperty(nameof(Job.JobLocation))]
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
