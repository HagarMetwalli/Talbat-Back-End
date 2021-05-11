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
    public class JobService : IGenericService<Job>
    {
        private static ConcurrentDictionary<int, Job> JobsCache;
        private TalabatContext db;

        public JobService(TalabatContext db)
        {
            this.db = db;
            if (JobsCache == null)
            {
                JobsCache = new ConcurrentDictionary<int, Job>(
                    db.Jobs.ToDictionary(o => o.JobId));
            }
        }

        public async Task<Job> CreatAsync(Job o)
        {
            EntityEntry<Job> added = await db.Jobs.AddAsync(o);
            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                return JobsCache.AddOrUpdate(o.JobId, o, UpdateCache);
            }

            else
            {
                return null;
            }
        }

        private Job UpdateCache(int id, Job o)
        {
            Job old;
            if (JobsCache.TryGetValue(id, out old))
            {
                if (JobsCache.TryUpdate(id, o, old))
                {
                    return o;
                }
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Job c = db.Jobs.Find(id);

            db.Jobs.Remove(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return JobsCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Job>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<Job>>(() => JobsCache.Values);

        public Task<Job> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                JobsCache.TryGetValue(id, out Job c);
                return c;
            });
        }

        public async Task<Job> UpdateAsync(int id, Job c)
        {
            db.Jobs.Update(c);
            db.Jobs.Update(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }

        public Task<Job> UpdateAsync(Job item)
        {
            throw new System.NotImplementedException();
        }
    }
}
