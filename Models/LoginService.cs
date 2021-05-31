using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Talbat.Models
{
    [NotMapped]
    public class LoginService
    {
        public string clientEmail { get; set; }
        public string clientPassword { get; set; }
    }
}
