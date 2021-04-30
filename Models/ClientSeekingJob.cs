using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class ClientSeekingJob
    {
        public int ClientId { get; set; }
        public int JobId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Job Job { get; set; }
    }
}
