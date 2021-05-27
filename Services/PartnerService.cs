using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class PartnerService : IGenericService<Partner>
    {
        private TalabatContext _db;
        public PartnerService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Partner> CreatAsync(Partner Partner)
        {
            await _db.Partners.AddAsync(Partner);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return Partner;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            Partner Partner = await RetriveAsync(id);
            _db.Partners.Remove(Partner);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IList<Partner>> RetriveAllAsync()
        {
            return Task<IList>.Run<IList<Partner>>(() => _db.Partners.ToList());
        }
        public Task<Partner> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Partners.Find(id));
        }

        public async Task<Partner> UpdateAsync(Partner Partner)
        {
            _db = new TalabatContext();
            _db.Partners.Update(Partner);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return Partner;
            return null;
        }

    }
}

