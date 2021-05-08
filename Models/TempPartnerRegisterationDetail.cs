using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class TempPartnerRegisterationDetail
    {
        public int TempPartnerStoreId { get; set; }
        public string PartnerFname { get; set; }
        public string PartnerLname { get; set; }
        public string StoreCountry { get; set; }
        public string PartnerPhoneNumber { get; set; }
        public string PartnerEmail { get; set; }
        public string PartnerContactRole { get; set; }
        public string StoreName { get; set; }
        public int? StoreBranchesNo { get; set; }
        public string StoreContact { get; set; }
        public int? StoreAddress { get; set; }
        public byte[] StoreStatus { get; set; }
        public int? StoreTypeId { get; set; }

        public virtual StoreType StoreType { get; set; }
    }
}
