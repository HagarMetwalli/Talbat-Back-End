using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
     public interface IRegions:IGeneric<Region>
    {
        public Region RetrivebyRegionnameAsync(string regionName);
    }
}
