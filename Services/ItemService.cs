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
    public class ItemService:IGenericService<Item>
    {
        private static ConcurrentDictionary<int, Item> ItemsCache;
        private TalabatContext db;
        public ItemService(TalabatContext db)
        {
            this.db = db;
            if (ItemsCache == null)
            {
                ItemsCache = new ConcurrentDictionary<int, Item>(
                    db.Items.ToDictionary(i => i.ItemId));
            }
        }
        public async Task<Item> CreatAsync(Item i)
        {
            EntityEntry<Item> added = await db.Items.AddAsync(i);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return ItemsCache.AddOrUpdate(i.ItemId, i, UpdateCache);
            }
            else
            {
                return null;
            }
        }
        private Item UpdateCache(int id, Item c)
        {
            Item old;
            if (ItemsCache.TryGetValue(id, out old))
            {
                if (ItemsCache.TryUpdate(id, c, old))
                {
                    return c;
                }
            }
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            Item c = db.Items.Find(id);
            db.Items.Remove(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return ItemsCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Item>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<Item>>(() => ItemsCache.Values);

        public Task<Item> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                ItemsCache.TryGetValue(id, out Item c);
                return c;
            });
        }

        public async Task<Item> UpdateAsync(int id, Item c)
        {
            db.Items.Update(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }
    }
}
