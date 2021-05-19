using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IStoreService : IGenericService<Store>
    {
        public Task<IEnumerable<String>> RetriveMostCommonStoreAsync();
        public Task<IEnumerable<object>> RetriveMostCommonCuisineAsync();

    }
}
