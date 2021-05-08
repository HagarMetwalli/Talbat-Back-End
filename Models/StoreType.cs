using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class StoreType
    {
        public StoreType()
        {
            Stores = new HashSet<Store>();
            TempPartnerRegisterationDetails = new HashSet<TempPartnerRegisterationDetail>();
        }

        public int StoreTypeId { get; set; }
        public string StoreType1 { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<TempPartnerRegisterationDetail> TempPartnerRegisterationDetails { get; set; }
    }
}
