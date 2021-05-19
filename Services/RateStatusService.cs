using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class RateStatusService : IGenericService<RateStatus>
    {
        private TalabatContext _db;
        public RateStatusService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<RateStatus> CreatAsync(RateStatus RateStatus)
        {
            await _db.RateStatuses.AddAsync(RateStatus);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return RateStatus;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            RateStatus RateStatus = await RetriveAsync(id);
            _db.RateStatuses.Remove(RateStatus);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IEnumerable<RateStatus>> RetriveAllAsync()
        {
            return Task<IEnumerable>.Run<IEnumerable<RateStatus>>(() => _db.RateStatuses);
        }
        public Task<RateStatus> RetriveAsync(int id)
        {
            return Task.Run(() => _db.RateStatuses.Find(id));
        }

        public async Task<RateStatus> UpdateAsync(RateStatus RateStatus)
        {
            _db = new TalabatContext();
            _db.RateStatuses.Update(RateStatus);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return RateStatus;
            return null;
        }

    }
}

