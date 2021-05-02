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
    public class JobTypeService : IGenericService<JobType>
    {
        private static ConcurrentDictionary<int, JobType> JobTypesCache;
        private TalabatContext db;

        public JobTypeService(TalabatContext db)
        {
            this.db = db;
            if (JobTypesCache == null)
            {
                 JobTypesCache = new ConcurrentDictionary<int, JobType>(
                    db.JobTypes.ToDictionary(o => o.JobTypeId));
            }
        }

        public async Task<JobType> CreatAsync(JobType o)
        {
            EntityEntry<JobType> added = await db.JobTypes.AddAsync(o);
            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                return JobTypesCache.AddOrUpdate(o.JobTypeId, o, UpdateCache);
            }

            else
            {
                return null;
            }
        }

        private JobType UpdateCache(int id, JobType o)
        {
            JobType old;
            if (JobTypesCache.TryGetValue(id, out old))
            {
                if (JobTypesCache.TryUpdate(id, o, old))
                {
                    return o;
                }
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            JobType c = db.JobTypes.Find(id);

            db.JobTypes.Remove(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return JobTypesCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<JobType>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<JobType>>(() => JobTypesCache.Values);

        public Task<JobType> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                JobTypesCache.TryGetValue(id, out JobType c);
                return c;
            });
        }

        public async Task<JobType> UpdateAsync(int id, JobType c)
        {
            db.JobTypes.Update(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }


    }
}
