using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class SubItemCategoryService : IGeneric<SubItemCategory>
    {
        private TalabatContext _db;
        public SubItemCategoryService(TalabatContext db)
        {
            _db = db;
        }
        public Task<List<SubItemCategory>> RetriveAllAsync()
        {
            try
            {
                return Task<List<SubItemCategory>>.Run<List<SubItemCategory>>(() => _db.SubItemCategories.ToList());
            }
            catch
            {
                return null;
            }
        }

        public Task<SubItemCategory> RetriveAsync(int id)
        {
            try { 
            return Task.Run(() => _db.SubItemCategories.Find(id));
            }
            catch
            {
                return null;
            }
        }

        public async Task<SubItemCategory> CreatAsync(SubItemCategory SubItemCategory)
        {
            try { 
            await _db.SubItemCategories.AddAsync(SubItemCategory);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return SubItemCategory;
            return null;
            }
            catch
            {
                return null;
            }
        }
        public async Task<SubItemCategory> PatchAsync(SubItemCategory SubItemCategory)
        {
            try { 
            _db = new TalabatContext();
            _db.SubItemCategories.Update(SubItemCategory);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return SubItemCategory;
            return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try { 
            SubItemCategory SubItemCategory = await RetriveAsync(id);
            _db.SubItemCategories.Remove(SubItemCategory);
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
    }
}
