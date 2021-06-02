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

        public Task<ItemCategory> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.ItemCategories.Find(id));
            }
            catch
            {
                return null;
            }
        }

        public Task<ItemCategory> RetriveByNameAsync(string itemCategoryName)
        {
            try
            {
                var ItemCategory = _db.ItemCategories.FirstOrDefault(s => s.ItemCategoryName == itemCategoryName);

                return Task<ItemCategory>.Run<ItemCategory>(() => ItemCategory);
            }
            catch
            {
                return null;
            }

        }
        public async Task<ItemCategory> CreatAsync(ItemCategory itemCategory)
        {
            try
            {
                using(var db = new TalabatContext())
                {
                    await db.ItemCategories.AddAsync(itemCategory);
                    int affected = await db.SaveChangesAsync();

                    if (affected == 1)
                    {
                        return itemCategory;
                    }
                    return null;
                }
            }
            catch 
            {
                return null;
            }

        }
        public async Task<ItemCategory> PatchAsync(ItemCategory itemCategory)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    db.ItemCategories.Update(itemCategory);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return itemCategory;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {

            try
            {
                using (var db = new TalabatContext())
                {
                    ItemCategory itemCategory = await RetriveAsync(id);
                    db.ItemCategories.Remove(itemCategory);
                    int affected = await db.SaveChangesAsync();

                    if (affected == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
            
        }

        public Task<List<ItemCategory>> RetriveAllAsync()
        {
            try
            {
                return Task<IList>.Run<List<ItemCategory>>(() => _db.ItemCategories.ToList());
            }
            catch 
            {
                return null;
            }
        }

    }
}
