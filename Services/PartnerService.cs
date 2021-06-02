using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class PartnerService : IGeneric<Partner>
    {
        private TalabatContext _db;
        public PartnerService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Partner> CreatAsync(Partner Partner)
        {
            try
            {
                await _db.Partners.AddAsync(Partner);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return Partner;
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
                Partner Partner = await RetriveAsync(id);
                _db.Partners.Remove(Partner);
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

        public Task<List<Partner>> RetriveAllAsync()
        {
            try { 
            return Task<List<Partner>>.Run<List<Partner>>(() => _db.Partners.ToList());
            }
            catch
            {
                return null;
            }
        }
        public Task<Partner> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.Partners.Find(id));
            }
            catch
            {
                return null;
            }
        }

        public async Task<Partner> PatchAsync(Partner Partner)
        {
            try
            {
                _db = new TalabatContext();
                _db.Partners.Update(Partner);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return Partner;
                return null;
            }
            catch
            {
                return null;
            }
        }

        //public Task<Client> RetriveByEmail(string Email)
        //public Task<string> Login(Login obj)

    }
}

