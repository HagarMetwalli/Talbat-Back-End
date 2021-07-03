using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
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
        public async Task<Item> CreatefileAsync(Item item, IFormFile imgFile)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    await db.Items.AddAsync(item);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {

                        if (imgFile != null)
                        {
                            if (imgFile.Length > 0)
                            {
                                //Getting FileName
                                var fileName = Path.GetFileName(imgFile.FileName);

                                ////Assigning Unique Filename (Guid)
                                //var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                                //Getting file Extension
                                var fileExtension = Path.GetExtension(fileName);

                                // concatenating  FileName + FileExtension
                                var newFileName = String.Concat(item.ItemId, fileExtension);
                                item.ItemImage = "https://localhost:44311/Images/Items/" + newFileName;
                               
                                // Combines two strings into a path.
                                var filepath =
                                new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images/Items")).Root + $@"\{newFileName}";

                                using (FileStream fs = System.IO.File.Create(filepath))
                                {
                                    imgFile.CopyTo(fs);
                                    fs.Flush();
                                }
                                db.SaveChanges();
                                return item;
                            }

                            return item;

                        }
                       return null;
                    }
                    return item;
                }
            }

            catch
            {
                return null;
            }
        }
        public async Task<Item> PatchfileAsync(Item item, IFormFile imgFile)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    if (imgFile == null)
                    {
                        var _item = db.Items.Single(i => i.ItemId == item.ItemId);
                        item.ItemImage = _item.ItemImage;
                        db.SaveChanges();
                        return item;
                    }
                    db.Items.Update(item);

                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {  
                        if (imgFile != null)
                        {
                            if (imgFile.Length > 0)
                            {
                                //Getting FileName
                                var fileName = Path.GetFileName(imgFile.FileName);

                                ////Assigning Unique Filename (Guid)
                                //var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                                //Getting file Extension
                                var fileExtension = Path.GetExtension(fileName);

                                // concatenating  FileName + FileExtension
                                var newFileName = String.Concat(item.ItemId, fileExtension);
                                item.ItemImage = "https://localhost:44311/Images/Items/" + newFileName;

                                // Combines two strings into a path.
                                var filepath =
                                new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images/Items")).Root + $@"\{newFileName}";

                                using (FileStream fs = System.IO.File.Create(filepath))
                                {
                                    imgFile.CopyTo(fs);
                                    fs.Flush();
                                }
                                db.SaveChanges();
                                return item;
                            }

                            return item;

                        }
                        return null;
                    }
                    return item;
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

        public Task<Item> CreatAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
