using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    [Table("Client_Seeking_Jobs")]
    [Index(nameof(JobId), Name = "IX_Client_Seeking_Jobs_Job_Id")]
    public partial class ClientSeekingJob
    {
        [Key]
        public int ClientId { get; set; }

        [Key]
        public int JobId { get; set; }


        [ForeignKey(nameof(ClientId))]
        [InverseProperty("ClientSeekingJobs")]
        public virtual Client Client { get; set; }

        [ForeignKey(nameof(JobId))]
        [InverseProperty("ClientSeekingJobs")]
        public virtual Job Job { get; set; }
    }
}
