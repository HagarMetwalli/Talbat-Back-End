using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        
        [HttpGet]
        public City Get()
        {
            using (var db = new TalabatContext())
            {
                var c = new City();
                c.CityName = "tanta";
                db.Cities.Add(c);
                db.SaveChanges();
                return c;

            }
        }
    }
}
