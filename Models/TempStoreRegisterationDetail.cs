using System;
using System.Collections.Generic;

#nullable disable

namespace Talbat.Models
{
    public partial class TempStoreRegisterationDetail
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int? StoreBranchesNo { get; set; }
        public string StoreType { get; set; }
        public string StoreContact { get; set; }
        public string StoreAddress { get; set; }
        public byte[] StoreStatus { get; set; }
    }
}
