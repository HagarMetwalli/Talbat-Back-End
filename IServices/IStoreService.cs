using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IStoreService : IGenericService<Store>
    {
        Task<IEnumerable<String>> RetriveMostCommonStoreAsync();
        Task<IEnumerable<object>> RetriveMostCommonCuisineAsync();
        Task<List<Item>> RetrieveStoreMenuItemsAsync(int Id);


    }
}
