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
    public class JobService : IGeneric<Job>
    {
        //private TalabatContext _db;
        //public JobService(TalabatContext db)
        //{
        //    _db = db;
        //}

        public Task<List<Job>> RetriveAllAsync()
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    var jobs = db.Jobs.ToList();
                    return Task.Run(() => jobs);
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public Task<Job> RetriveAsync(int id)
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    var job = db.Jobs.Find(id);
                    return Task.Run(() => job);
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public async Task<Job> CreatAsync(Job job)
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    await db.Jobs.AddAsync(job);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return job;
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
                    Job job = await RetriveAsync(id);
                    db.Jobs.Remove(job);

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

        public async Task<Job> PatchAsync(Job job)
        {
            using(var db= new TalabatContext())
            {
                try
                {
                    db.Jobs.Update(job);

                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return job;
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
