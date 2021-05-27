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
        private TalabatContext _db;
        public ItemService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Item> CreatAsync(Item item)
        {
            await _db.Items.AddAsync(item);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return item;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            Item item = await RetriveAsync(id);
            _db.Items.Remove(item);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IList<Item>> RetriveAllAsync()
        {
            return Task<IList>.Run<IList<Item>>(() => _db.Items.ToList());
        }
        public Task<Item> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Items.Find(id));
        }
        public async Task<Item> UpdateAsync(Item item)
        {
            _db = new TalabatContext();
            _db.Items.Update(item);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return item;
            return null;
        }
    }
}
