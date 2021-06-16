using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class TempPartnerRegisterationDetailService : IGeneric<TempPartnerRegisterationDetail>
    {
        private TalabatContext _db;
        public TempPartnerRegisterationDetailService(TalabatContext db)
        {
            _db = db;
        }
        public Task<List<TempPartnerRegisterationDetail>> RetriveAllAsync()
        {
            try
            {
                return Task<List<TempPartnerRegisterationDetail>>.Run<List<TempPartnerRegisterationDetail>>(() => _db.TempPartnerRegisterationDetails.ToList());
            }
            catch
            {
                return null;
            }
            }

        public Task<TempPartnerRegisterationDetail> RetriveAsync(int id)
        {
            try { 
            return Task.Run(() => _db.TempPartnerRegisterationDetails.Find(id));
            }
            catch
            {
                return null;
            }
        }

        public async Task<TempPartnerRegisterationDetail> CreatAsync(TempPartnerRegisterationDetail TempPartnerRegisterationDetail)
        {
            try
            {
                await _db.TempPartnerRegisterationDetails.AddAsync(TempPartnerRegisterationDetail);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return TempPartnerRegisterationDetail;
            return null;
             }
            catch
            {
                return null;
            }
        }
        public async Task<TempPartnerRegisterationDetail> PatchAsync(TempPartnerRegisterationDetail TempPartnerRegisterationDetail)
        {
            try { 
            _db = new TalabatContext();
            _db.TempPartnerRegisterationDetails.Update(TempPartnerRegisterationDetail);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return TempPartnerRegisterationDetail;
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
            TempPartnerRegisterationDetail TempPartnerRegisterationDetail = await RetriveAsync(id);
            _db.TempPartnerRegisterationDetails.Remove(TempPartnerRegisterationDetail);
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
