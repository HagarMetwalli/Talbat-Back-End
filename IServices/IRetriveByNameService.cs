using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IRetriveByNameService<T>:IGenericService<T>
    {
        public Task<T> RetriveByNameAsync(string name);

    }
}
