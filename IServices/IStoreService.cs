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
        public Task<List<Store>> RetriveStoresBasedLocationAsync(double long1, double lat1 );
        public Task<Store> RetriveByNameAsync(string name);
        public Task<List<Item>> RetriveTopItemsAsync(int storeId);

        //public Task<List<Store>> RetriveStorebyFilter(string filter);
        public Task<List<Store>> RetriveStoreWithTypeIdAsync(int storeTypeId);
        public Task<List<Store>> RetriveStoreWithCuisineIdAsync(int CuisineId);
        public Task<List<ItemCategory>> RetriveItemCategoriesAsync(int storeId);
        public Task<Store> RetriveStoreInLocationAsync(int storeId, double lat1, double long1);
        public Task<List<Item>> RetriveAllWithNameAsync(int id);




    }
}
