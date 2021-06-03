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
    public class JobLocationService : IGeneric<JobLocation>
    {
        //private TalabatContext _db;
        //public JobLocationService(TalabatContext db)
        //{
        //    _db = db;
        //}

        public Task<List<JobLocation>> RetriveAllAsync()
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    var jobLocations = db.JobLocations.ToList();
                    return Task.Run(() => jobLocations);
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public Task<JobLocation> RetriveAsync(int id)
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    var jobLocation = db.JobLocations.Find(id);
                    return Task.Run(() => jobLocation);
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public async Task<JobLocation> CreatAsync(JobLocation jobLocation)
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    await db.JobLocations.AddAsync(jobLocation);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return jobLocation;
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
                    JobLocation jobLocation = await RetriveAsync(id);
                    db.JobLocations.Remove(jobLocation);

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

        public async Task<JobLocation> PatchAsync(JobLocation jobLocation)
        {
            using(var db= new TalabatContext())
            {
                try
                {
                    db.JobLocations.Update(jobLocation);

                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return jobLocation;
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
