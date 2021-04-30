using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class JobLocation
    {
        public JobLocation()
        {
            Jobs = new HashSet<Job>();
        }

        public int JobLocationId { get; set; }
        public string JobLocationName { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
