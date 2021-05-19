using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class SubItemCategoryService : IGenericService<SubItemCategory>
    {
        private TalabatContext _db;
        public SubItemCategoryService(TalabatContext db)
        {
            _db = db;
        }
        public Task<IEnumerable<SubItemCategory>> RetriveAllAsync()
        {
            return Task<IEnumerable>.Run<IEnumerable<SubItemCategory>>(() => _db.SubItemCategories);
        }

        public Task<SubItemCategory> RetriveAsync(int id)
        {
            return Task.Run(() => _db.SubItemCategories.Find(id));
        }

        public async Task<SubItemCategory> CreatAsync(SubItemCategory SubItemCategory)
        {
            await _db.SubItemCategories.AddAsync(SubItemCategory);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return SubItemCategory;
            return null;
        }
        public async Task<SubItemCategory> UpdateAsync(SubItemCategory SubItemCategory)
        {
            _db = new TalabatContext();
            _db.SubItemCategories.Update(SubItemCategory);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return SubItemCategory;
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            SubItemCategory SubItemCategory = await RetriveAsync(id);
            _db.SubItemCategories.Remove(SubItemCategory);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }
    }
}
