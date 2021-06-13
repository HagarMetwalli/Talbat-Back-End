using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class SystemReviewService : IReview<SystemReview>
    {
        private TalabatContext _db;
        public SystemReviewService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<SystemReview> CreatAsync(SystemReview SystemReview)
        {
            try
            {
                
                
                    await _db.SystemReview.AddAsync(SystemReview);
                    int affected = await _db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return SystemReview;
                    }
                    return null;
                
            }
            catch
            {
                return null;
            }

        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                    SystemReview SystemReview = await RetriveAsync(id);
                    _db.SystemReview.Remove(SystemReview);
                    int affected = await _db.SaveChangesAsync();

                    if (affected == 1)
                    {
                        return true;
                    }
                    return false;
                
            }
            catch
            {
                return false;
            }
        }

        public Task<List<SystemReview>> RetriveAllAsync()
        {
            try
            {
                return Task<List<List<SystemReview>>>.Run<List<SystemReview>>(() => _db.SystemReview.ToList());
            }
            catch
            {
                return null;
            }
        }
        public Task<SystemReview> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.SystemReview.Find(id));
            }
            catch
            {
                return null;
            }
        }



        public async Task<SystemReview> PatchAsync(SystemReview SystemReview)
        {

            try
            {
               
                    _db.SystemReview.Update(SystemReview);
                    int affected = await _db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return SystemReview;
                    }
                    return null;
           
            }
            catch
            {
                return null;
            }
        }

        public bool IfHaveReview(int Clintid)
        {
            try
            {
                var exsite = _db.SystemReview.Where(a => a.ClientId == Clintid).ToList();
              
                if (exsite.Count()== 0)
                {
                    return false;
                }
                return true;

            }
            catch
            {
                return false;
            }
        }

    }
}
