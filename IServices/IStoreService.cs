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
        public Task<List<OrderItem>> RetriveTopItemsAsync(int storeId);
        public Task<List<Store>> RetriveStoreInAreaAsync(string area);
        public Task<List<Store>> RetriveStoreWithTypeIdAsync(int storeTypeId);
        public Task<List<Store>> RetriveStoreWithCuisineIdAsync(int CuisineId);
        public Task<Store> RetriveStoreInLocationAsync(string storeName, double lat1, double long1);



    }
}
