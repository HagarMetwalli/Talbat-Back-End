using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class SubItemsService : IGeneric<SubItem>
    {
        private TalabatContext _db;
        public SubItemsService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<SubItem> CreatAsync(SubItem SubItem)
        {
            try
            {
                await _db.SubItems.AddAsync(SubItem);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return SubItem;
                return null;
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
                SubItem SubItem = await RetriveAsync(id);
                _db.SubItems.Remove(SubItem);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<SubItem>> RetriveAllAsync()
        {
            try { 
            return Task<List<SubItem>>.Run<List<SubItem>>(() => _db.SubItems.ToList());
            }
            catch
            {
                return null;
            }
        }
        public Task<SubItem> RetriveAsync(int id)
        {
            try { 
            return Task.Run(() => _db.SubItems.Find(id));
            }
            catch
            {
                return null;
            }
        }

        public async Task<SubItem> PatchAsync(SubItem SubItem)
        {
            try { 
            _db = new TalabatContext();
            _db.SubItems.Update(SubItem);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return SubItem;
            return null;
            }
            catch
            {
                return null;
            }
        }

    }
}
