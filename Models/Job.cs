using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Talbat.Models
{
    public partial class Job
    {
        public Job()
        {
            ClientSeekingJobs = new HashSet<ClientSeekingJob>();
        }

        [Key]
        public int JobId { get; set; }

        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(500)]
        public string JobDescription { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? JobPostedTime { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int JobCategoryId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int JobLocationId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int JobTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int JobPeriodId { get; set; }

        public virtual JobCategory JobCategory { get; set; }
        public virtual JobLocation JobLocation { get; set; }
        public virtual JobPeriod JobPeriod { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual ICollection<ClientSeekingJob> ClientSeekingJobs { get; set; }
    }
}
