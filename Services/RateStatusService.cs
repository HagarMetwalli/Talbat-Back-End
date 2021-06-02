using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class RateStatusService : IGeneric<RateStatus>
    {
        private TalabatContext _db;
        public RateStatusService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<RateStatus> CreatAsync(RateStatus RateStatus)
        {
            try
            {
                await _db.RateStatuses.AddAsync(RateStatus);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return RateStatus;
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
                RateStatus RateStatus = await RetriveAsync(id);
                _db.RateStatuses.Remove(RateStatus);
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

        public Task<List<RateStatus>> RetriveAllAsync()
        {
            try
            {
                return Task<List<RateStatus>>.Run<List<RateStatus>>(() => _db.RateStatuses.ToList());
            }
            catch
            {
                return null;
            }
        }
        public Task<RateStatus> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.RateStatuses.Find(id));
            }
            catch
            {
                return null;
            }
        }

        public async Task<RateStatus> PatchAsync(RateStatus RateStatus)
        {
            try
            {
                _db = new TalabatContext();
                _db.RateStatuses.Update(RateStatus);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return RateStatus;
                return null;
            }
            catch
            {
                return null;
            }
        }

    }
}

