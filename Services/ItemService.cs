using Microsoft.EntityFrameworkCore;
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
    public class ItemService: IItemService
    {
        private TalabatContext _db;
        public ItemService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Item> CreatAsync(Item item)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    await _db.Items.AddAsync(item);
                    int affected = await _db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return item;
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
                    Item item = await RetriveAsync(id);
                    var orderItems = db.OrderItems.Where(i => i.ItemId == id).ToList();
                    if (orderItems != null)
                    {
                        foreach (var orderItem in orderItems)
                        {
                            db.OrderItems.Remove(orderItem);
                        }
                        
                    }
                    db.Items.Remove(item);
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

        public Task<List<Item>> RetriveAllAsync()
        {
            try
            {
                return Task<IList>.Run<List<Item>>(() => _db.Items.ToList());
            }
            catch 
            {
                return null;
            }
        }

        public Task<Item> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.Items.Find(id));
            }
            catch
            {
                return null;
            }
        }
        public Task<List<SubItem>> RetriveSubItemsByItemIdAsync(int itemId)
        {
            try
            {
                var subItems = _db.SubItems.Where(s => s.ItemId == itemId).ToList();
                return Task<IList>.Run<List<SubItem>>(() => subItems);
            }
            catch
            {
                return null;
            }
        }
        public Task<List<SubItemCategory>> RetriveSubItemsCategoriesByItemIdAsync(int itemId)
        {
            try
            {
                var SubItemsCategories = _db.SubItems
                    .Include("SubItemCategory")
                    .Where(x=>x.ItemId==itemId).Select(x=>x.SubItemCategory)
                    .Distinct()
                    .ToList();

                return Task<IList>.Run<List<SubItemCategory>>(() => SubItemsCategories);
            }
            catch
            {
                return null;
            }
        }
        public Task<List<SubItem>> RetriveSubItemsAsync(int itemId)
        {
            try
            {
                var subItems = _db.SubItems.Where(i => i.ItemId == itemId).ToList();
                return Task<IList>.Run<List<SubItem>>(() => subItems);
            }
            catch
            {
                return null;
            }
        }
        public async Task<Item> PatchAsync(Item item)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    db.Items.Update(item);
                    int affected = await _db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return item;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
