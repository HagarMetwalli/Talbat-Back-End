using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IStoreService : IGeneric<Store>
    {
        public Task<IEnumerable<String>> RetriveMostCommonAsync();
        public Task<List<String>> RetriveCategoriesAsync(int id);
        public Task<IEnumerable<Item>> RetriveCategoryItemsAsync(int StoreId, int CategoryId);
        public Task<List<Item>> RetriveMenuAsync(int storeId);
        public Task<Store> RetriveByNameAsync(string name);

    }
}
