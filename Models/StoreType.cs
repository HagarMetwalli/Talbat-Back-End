using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class StoreType
    {
        public StoreType()
        {
            //Stores = new HashSet<Store>();
            //TempPartnerRegisterationDetails = new HashSet<TempPartnerRegisterationDetail>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoreTypeId { get; set; }

        public string StoreTypeName { get; set; }
       

        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<TempPartnerRegisterationDetail> TempPartnerRegisterationDetails { get; set; }
    }
}
