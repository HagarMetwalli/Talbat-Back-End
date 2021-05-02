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
    public class JobCategoryService : IGenericService<JobCategory>
    {
        private static ConcurrentDictionary<int, JobCategory> JobCategoriesCache;
        private TalabatContext db;

        public JobCategoryService(TalabatContext db)
        {
            this.db = db;
            if (JobCategoriesCache == null)
            {
                JobCategoriesCache = new ConcurrentDictionary<int, JobCategory>(
                    db.JobCategories.ToDictionary(o => o.JobCategoryId));
            }
        }

        public async Task<JobCategory> CreatAsync(JobCategory o)
        {
            EntityEntry<JobCategory> added = await db.JobCategories.AddAsync(o);
            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                return JobCategoriesCache.AddOrUpdate(o.JobCategoryId, o, UpdateCache);
            }

            else
            {
                return null;
            }
        }

        private JobCategory UpdateCache(int id, JobCategory o)
        {
            JobCategory old;
            if (JobCategoriesCache.TryGetValue(id, out old))
            {
                if (JobCategoriesCache.TryUpdate(id, o, old))
                {
                    return o;
                }
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            JobCategory c = db.JobCategories.Find(id);

            db.JobCategories.Remove(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return JobCategoriesCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<JobCategory>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<JobCategory>>(() => JobCategoriesCache.Values);

        public Task<JobCategory> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                JobCategoriesCache.TryGetValue(id, out JobCategory c);
                return c;
            });
        }

        public async Task<JobCategory> UpdateAsync(int id, JobCategory c)
        {
            db.JobCategories.Update(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }


    }
}
