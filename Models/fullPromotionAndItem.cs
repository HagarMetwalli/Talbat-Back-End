using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Talbat.Models
{
    [NotMapped]
    public class fullPromotionAndItem
    {
        public Item item{ get; set; }
        public Promotion promotion{ get; set; }
    }
}
