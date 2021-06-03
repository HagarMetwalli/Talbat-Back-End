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
    public class JobTypeService : IGeneric<JobType>
    {
        //private TalabatContext _db;
        //public JobTypeService(TalabatContext db)
        //{
        //    _db = db;
        //}

        public Task<List<JobType>> RetriveAllAsync()
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    var jobTypes = db.JobTypes.ToList();
                    return Task.Run(() => jobTypes);
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public Task<JobType> RetriveAsync(int id)
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    var jobType = db.JobTypes.Find(id);
                    return Task.Run(() => jobType);
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public async Task<JobType> CreatAsync(JobType jobType)
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    await db.JobTypes.AddAsync(jobType);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return jobType;
                    }

                    return null;
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    JobType jobType = await RetriveAsync(id);
                    db.JobTypes.Remove(jobType);

                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return true;
                    }

                    return false;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
        }

        public async Task<JobType> PatchAsync(JobType jobType)
        {
            using(var db= new TalabatContext())
            {
                try
                {
                    db.JobTypes.Update(jobType);

                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return jobType;
                    }

                    return null;
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

    }
}
