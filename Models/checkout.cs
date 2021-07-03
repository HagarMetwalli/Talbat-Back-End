using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talbat.Models
{
    public class checkout
    {
        public int PaymentId { get; set; }
        public int Type { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}
