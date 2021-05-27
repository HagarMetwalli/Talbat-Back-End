using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class TempPartnerRegisterationDetailService : IGenericService<TempPartnerRegisterationDetail>
    {
        private TalabatContext _db;
        public TempPartnerRegisterationDetailService(TalabatContext db)
        {
            _db = db;
        }
        public Task<IList<TempPartnerRegisterationDetail>> RetriveAllAsync()
        {
            return Task<IList>.Run<IList<TempPartnerRegisterationDetail>>(() => _db.TempPartnerRegisterationDetails.ToList());
        }

        public Task<TempPartnerRegisterationDetail> RetriveAsync(int id)
        {
            return Task.Run(() => _db.TempPartnerRegisterationDetails.Find(id));
        }

        public async Task<TempPartnerRegisterationDetail> CreatAsync(TempPartnerRegisterationDetail TempPartnerRegisterationDetail)
        {
            await _db.TempPartnerRegisterationDetails.AddAsync(TempPartnerRegisterationDetail);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return TempPartnerRegisterationDetail;
            return null;
        }
        public async Task<TempPartnerRegisterationDetail> UpdateAsync(TempPartnerRegisterationDetail TempPartnerRegisterationDetail)
        {
            _db = new TalabatContext();
            _db.TempPartnerRegisterationDetails.Update(TempPartnerRegisterationDetail);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return TempPartnerRegisterationDetail;
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            TempPartnerRegisterationDetail TempPartnerRegisterationDetail = await RetriveAsync(id);
            _db.TempPartnerRegisterationDetails.Remove(TempPartnerRegisterationDetail);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }
    }
}
