using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class JobCategory
    {
        public JobCategory()
        {
            Jobs = new HashSet<Job>();
        }

        public int JobCategoryId { get; set; }
        public string JobCategoryType { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
