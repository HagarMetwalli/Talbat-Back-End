using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class Partner
    {
        public int PartnerId { get; set; }
        public string PartnerFname { get; set; }
        public string PartnerLname { get; set; }
        public string PartnerEmail { get; set; }
        public int? PartnerPhoneNo { get; set; }
    }
}
