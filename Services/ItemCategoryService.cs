using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class ItemCategoryService : IItemCategoryService 
    {
        private TalabatContext _db;
        public ItemCategoryService(TalabatContext db)
        {
            _db = db;
        }

        public async Task<ItemCategory> CreatAsync(ItemCategory itemCategory)
        {
            await _db.ItemCategories.AddAsync(itemCategory);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return itemCategory;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            ItemCategory itemCategory = await RetriveAsync(id);
            _db.ItemCategories.Remove(itemCategory);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IList<ItemCategory>> RetriveAllAsync()
        {
            return Task<IList>.Run<IList<ItemCategory>>(() => _db.ItemCategories.ToList());
        }
        public Task<ItemCategory> RetriveAsync(int id)
        {
            return Task.Run(() => _db.ItemCategories.Find(id));
        }

        public Task<ItemCategory> RetriveByNameAsync(string itemCategoryName)
        {
            var ItemCategory = _db.ItemCategories.FirstOrDefault(s => s.ItemCategoryName == itemCategoryName);

            return Task<ItemCategory>.Run<ItemCategory>(() => ItemCategory);
        }

        public async Task<ItemCategory> UpdateAsync(ItemCategory itemCategory)
        {
            _db = new TalabatContext();
            _db.ItemCategories.Update(itemCategory);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return itemCategory;
            return null;
        }
    }
}
