using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class StoreWorkingHour
    {
        public int StoreWorkingHourId { get; set; }
        public string StoreWorkingHourDay { get; set; }
        public int? StoreWorkingHourStart { get; set; }
        public int? StoreWorkingHourEnd { get; set; }
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}
