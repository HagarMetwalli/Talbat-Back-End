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
    public class ItemCategoryService : IGenericService<ItemCategory>
    {
        private static ConcurrentDictionary<int, ItemCategory> ItemCategoriesCache;
        private TalabatContext db;
        public ItemCategoryService(TalabatContext db)
        {
            this.db = db;
            if (ItemCategoriesCache == null)
            {
                ItemCategoriesCache = new ConcurrentDictionary<int, ItemCategory>(
                    db.ItemCategories.ToDictionary(i => i.ItemCategoryId));
            }
        }

        public async Task<ItemCategory> CreatAsync(ItemCategory c)
        {
            EntityEntry<ItemCategory> added = await db.ItemCategories.AddAsync(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return ItemCategoriesCache.AddOrUpdate(c.ItemCategoryId, c, UpdateCache);
            }
            else
            {
                return null;
            }
        }
        private ItemCategory UpdateCache(int id, ItemCategory c)
        {
            ItemCategory old;
            if (ItemCategoriesCache.TryGetValue(id, out old))
            {
                if (ItemCategoriesCache.TryUpdate(id, c, old))
                {
                    return c;
                }
            }
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            ItemCategory i = db.ItemCategories.Find(id);
            db.ItemCategories.Remove(i);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return ItemCategoriesCache.TryRemove(id, out i);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<ItemCategory>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<ItemCategory>>(() => ItemCategoriesCache.Values);

        public Task<ItemCategory> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                ItemCategoriesCache.TryGetValue(id, out ItemCategory i);
                return i;
            });
        }

        public async Task<ItemCategory> UpdateAsync(int id, ItemCategory i)
        {
            db.ItemCategories.Update(i);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, i);
            }
            return null;
        }

        public Task<ItemCategory> UpdateAsync(ItemCategory item)
        {
            throw new System.NotImplementedException();
        }
    }
}
