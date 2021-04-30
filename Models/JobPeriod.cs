using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class JobPeriod
    {
        public JobPeriod()
        {
            Jobs = new HashSet<Job>();
        }

        public int JobPeriodId { get; set; }
        public string JobPeriodName { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
