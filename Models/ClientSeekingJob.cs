using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class ClientSeekingJob
    {
        [Key, ForeignKey("Client")]
        public int ClientId { get; set; }
        [Key,ForeignKey("Job")]
        public int JobId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Job Job { get; set; }
    }
}
