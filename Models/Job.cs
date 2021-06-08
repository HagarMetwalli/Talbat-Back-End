using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    [Table("Job")]
    [Index(nameof(JobCategoryId), Name = "IX_Job_JobCategory_Id")]
    [Index(nameof(JobLocationId), Name = "IX_Job_JobLocation_Id")]
    [Index(nameof(JobPeriodId), Name = "IX_Job_JobPeriod_Id")]
    [Index(nameof(JobTypeId), Name = "IX_Job_JobType_Id")]
    public partial class Job
    {
        public Job()
        {
            //ClientSeekingJobs = new HashSet<ClientSeekingJob>();
        }

        [Key]
        public int JobId { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string JobTitle { get; set; }

        [Required]
        [StringLength(maximumLength: 500, MinimumLength = 1)]
        public string JobDescription { get; set; }

        [Required]
        public DateTime JobPostedTime { get; set; }

        [Required]
        public int JobCategoryId { get; set; }

        [Required]
        public int JobLocationId { get; set; }

        [Required]
        public int JobTypeId { get; set; }

        [Required]
        public int JobPeriodId { get; set; }


        [ForeignKey(nameof(JobCategoryId))]
        [InverseProperty("Jobs")]
        public virtual JobCategory JobCategory { get; set; }

        [ForeignKey(nameof(JobLocationId))]
        [InverseProperty("Jobs")]
        public virtual JobLocation JobLocation { get; set; }

        [ForeignKey(nameof(JobPeriodId))]
        [InverseProperty("Jobs")]
        public virtual JobPeriod JobPeriod { get; set; }

        [ForeignKey(nameof(JobTypeId))]
        [InverseProperty("Jobs")]
        public virtual JobType JobType { get; set; }

        [InverseProperty(nameof(ClientSeekingJob.Job))]
        public virtual ICollection<ClientSeekingJob> ClientSeekingJobs { get; set; }
    }
}
