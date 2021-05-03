using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class JobPeriodService : IGenericService<JobPeriod>
    {
        private static ConcurrentDictionary<int, JobPeriod> JobPeriodsCache;
        private TalabatContext db;

        public JobPeriodService(TalabatContext db)
        {
            this.db = db;
            if (JobPeriodsCache == null)
            {
                JobPeriodsCache = new ConcurrentDictionary<int, JobPeriod>(
                    db.JobPeriods.ToDictionary(o => o.JobPeriodId));
            }
        }

        public async Task<JobPeriod> CreatAsync(JobPeriod o)
        {
            EntityEntry<JobPeriod> added = await db.JobPeriods.AddAsync(o);
            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                return JobPeriodsCache.AddOrUpdate(o.JobPeriodId, o, UpdateCache);
            }

            else
            {
                return null;
            }
        }

        private JobPeriod UpdateCache(int id, JobPeriod o)
        {
            JobPeriod old;
            if (JobPeriodsCache.TryGetValue(id, out old))
            {
                if (JobPeriodsCache.TryUpdate(id, o, old))
                {
                    return o;
                }
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            JobPeriod c = db.JobPeriods.Find(id);

            db.JobPeriods.Remove(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return JobPeriodsCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<JobPeriod>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<JobPeriod>>(() => JobPeriodsCache.Values);

        public Task<JobPeriod> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                JobPeriodsCache.TryGetValue(id, out JobPeriod c);
                return c;
            });
        }

        public async Task<JobPeriod> UpdateAsync(int id, JobPeriod c)
        {
            db.JobPeriods.Update(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }


    }
}
