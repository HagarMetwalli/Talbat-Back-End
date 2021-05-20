using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IStoreService<T> : IGenericService<T>
    {
        public Task<IEnumerable<String>> RetriveMostCommonAsync();
        public Task<T> RetriveByNameAsync(string name);

    }
}
