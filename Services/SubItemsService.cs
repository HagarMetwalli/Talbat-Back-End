using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class SubItemsService : IGenericService<SubItem>
    {
        private TalabatContext _db;
        public SubItemsService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<SubItem> CreatAsync(SubItem SubItem)
        {
            await _db.SubItems.AddAsync(SubItem);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return SubItem;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            SubItem SubItem = await RetriveAsync(id);
            _db.SubItems.Remove(SubItem);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IList<SubItem>> RetriveAllAsync()
        {
            return Task<IList>.Run<IList<SubItem>>(() => _db.SubItems.ToList());
        }
        public Task<SubItem> RetriveAsync(int id)
        {
            return Task.Run(() => _db.SubItems.Find(id));
        }

        public async Task<SubItem> UpdateAsync(SubItem SubItem)
        {
            _db = new TalabatContext();
            _db.SubItems.Update(SubItem);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return SubItem;
            return null;
        }

    }
}
