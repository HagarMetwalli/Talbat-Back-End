using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class TempPartnerRegisterationDetail
    {
        public int PartnerId { get; set; }
        public string PartnerFname { get; set; }
        public string PartnerLname { get; set; }
        public string StoreCountry { get; set; }
        public string PartnerPhoneNumber { get; set; }
        public string PartnerEmail { get; set; }
        public string PartnerContactRole { get; set; }
    }
}
