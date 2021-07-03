using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface Icity : IGeneric<City>
    {
        public City RetrivebyCitynameAsync(string cityname);
    }
}
