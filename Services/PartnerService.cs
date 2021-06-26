using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Authentication;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class PartnerService : IUserService<Partner>
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
                Partner.PartnerEmail.ToLower();
                Partner.JoinDate = DateTime.Now;
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
            try
            {
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
                var currentPartner = _db.Partners.Find(Partner.PartnerId);
                Partner.PartnerEmail.ToLower();
                Partner.JoinDate = currentPartner.JoinDate;
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
        public Task<string> Login(Login obj)
        {
            try
            {
                obj.Email = obj.Email.ToLower();
                Partner partner = _db.Partners.FirstOrDefault(c => c.PartnerEmail == obj.Email);

                if (partner != null && partner.PartnerPassword == obj.Password)
                {
                    var tokenString = UserAuthentication.CreateToken(obj.Email);
                    return Task.Run(() => tokenString);
                }
                return (Task<string>)Task.Run(() => null);
            }
            catch
            {
                return (Task<string>)Task.Run(() => null);
            }
        }
        public Task<Partner> RetriveByEmail(string Email)
        {
            try
            {
                var partener = _db.Partners.FirstOrDefault(c => c.PartnerEmail == Email);
                return Task<Partner>.Run<Partner>(() => partener);
            }
            catch
            {
                return null;
            }
        }

    }
}

