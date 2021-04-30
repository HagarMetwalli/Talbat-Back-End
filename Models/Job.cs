using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class Job
    {
        public Job()
        {
            ClientSeekingJobs = new HashSet<ClientSeekingJob>();
        }

        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime? JobPostedTime { get; set; }
        public int JobCategoryId { get; set; }
        public int JobLocationId { get; set; }
        public int JobTypeId { get; set; }
        public int JobPeriodId { get; set; }

        public virtual JobCategory JobCategory { get; set; }
        public virtual JobLocation JobLocation { get; set; }
        public virtual JobPeriod JobPeriod { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual ICollection<ClientSeekingJob> ClientSeekingJobs { get; set; }
    }
}
