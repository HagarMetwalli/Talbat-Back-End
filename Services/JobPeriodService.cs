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
    public class JobPeriodService : IGeneric<JobPeriod>
    {
        //private TalabatContext _db;
        //public JobPeriodnService(TalabatContext db)
        //{
        //    _db = db;
        //}

        public Task<List<JobPeriod>> RetriveAllAsync()
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    var jobPeriods = db.JobPeriods.ToList();
                    return Task.Run(() => jobPeriods);
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public Task<JobPeriod> RetriveAsync(int id)
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    var jobPeriod = db.JobPeriods.Find(id);
                    return Task.Run(() => jobPeriod);
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public async Task<JobPeriod> CreatAsync(JobPeriod jobPeriod)
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    await db.JobPeriods.AddAsync(jobPeriod);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return jobPeriod;
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
                    JobPeriod jobPeriod = await RetriveAsync(id);
                    db.JobPeriods.Remove(jobPeriod);

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

        public async Task<JobPeriod> PatchAsync(JobPeriod jobPeriod)
        {
            using(var db= new TalabatContext())
            {
                try
                {
                    db.JobPeriods.Update(jobPeriod);

                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return jobPeriod;
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
