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
    public class JobLocationService : IGenericService<JobLocation>
    {
        private static ConcurrentDictionary<int, JobLocation> JobLocationsCache;
        private TalabatContext db;

        public JobLocationService(TalabatContext db)
        {
            this.db = db;
            if (JobLocationsCache == null)
            {
                JobLocationsCache = new ConcurrentDictionary<int, JobLocation>(
                    db.JobLocations.ToDictionary(o => o.JobLocationId));
            }
        }

        public async Task<JobLocation> CreatAsync(JobLocation o)
        {
            EntityEntry<JobLocation> added = await db.JobLocations.AddAsync(o);
            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                return JobLocationsCache.AddOrUpdate(o.JobLocationId, o, UpdateCache);
            }

            else
            {
                return null;
            }
        }

        private JobLocation UpdateCache(int id, JobLocation o)
        {
            JobLocation old;
            if (JobLocationsCache.TryGetValue(id, out old))
            {
                if (JobLocationsCache.TryUpdate(id, o, old))
                {
                    return o;
                }
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            JobLocation c = db.JobLocations.Find(id);

            db.JobLocations.Remove(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return JobLocationsCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<JobLocation>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<JobLocation>>(() => JobLocationsCache.Values);

        public Task<JobLocation> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                JobLocationsCache.TryGetValue(id, out JobLocation c);
                return c;
            });
        }

        public async Task<JobLocation> UpdateAsync(int id, JobLocation c)
        {
            db.JobLocations.Update(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }


    }
}
