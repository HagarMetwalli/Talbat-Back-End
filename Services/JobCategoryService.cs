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
    public class JobCategoryService : IGeneric<JobCategory>
    {
        //private TalabatContext _db;
        //public JobCategoryService(TalabatContext db)
        //{
        //    _db = db;
        //}

        public Task<List<JobCategory>> RetriveAllAsync()
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    var jobCategories = db.JobCategories.ToList();
                    return Task.Run(() => jobCategories);
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public Task<JobCategory> RetriveAsync(int id)
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    var jobCategory = db.JobCategories.Find(id);
                    return Task.Run(() => jobCategory);
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public async Task<JobCategory> CreatAsync(JobCategory jobCategory)
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    await db.JobCategories.AddAsync(jobCategory);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return jobCategory;
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
                    JobCategory jobCategory = await RetriveAsync(id);
                    db.JobCategories.Remove(jobCategory);

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

        public async Task<JobCategory> PatchAsync(JobCategory jobCategory)
        {
            using(var db= new TalabatContext())
            {
                try
                {
                    db.JobCategories.Update(jobCategory);

                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return jobCategory;
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
