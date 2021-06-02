using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class ClientOffer
    {
        [Key]
        [ForeignKey("Offer")]
        public int UserId { get; set; }
        [Key]
        [ForeignKey("User")]
        public int OfferId { get; set; }

        public virtual Offer Offer { get; set; }
        public virtual Client User { get; set; }
    }
}
