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
    public class DeliveryManService:IGeneric<DeliveryMan>
    {
        private TalabatContext _db;
        public DeliveryManService(TalabatContext db)
        {
            _db = db;
        }
        public Task<List<DeliveryMan>> RetriveAllAsync()
        {
            try
            {
                return Task<IList>.Run<List<DeliveryMan>>(() => _db.DeliveryMen.ToList());
            }
            catch
            {
                return null;
            }
        }
        public Task<DeliveryMan> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.DeliveryMen.Find(id));
            }
            catch
            {
                return null;
            }
        }
        public async Task<DeliveryMan> CreatAsync(DeliveryMan deliveryMan)
        {
            try
            {
                using(var db = new TalabatContext())
                {
                    await _db.DeliveryMen.AddAsync(deliveryMan);
                    int affected = await _db.SaveChangesAsync();

                    if (affected == 1)
                    {
                        return deliveryMan;
                    }
                    return null;
                }

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
                using (var db = new TalabatContext())
                {
                    DeliveryMan deliveryMan = await RetriveAsync(id);
                    db.DeliveryMen.Remove(deliveryMan);
                    int affected = await db.SaveChangesAsync();

                    if (affected == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<DeliveryMan> PatchAsync(DeliveryMan deliveryMan)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    db.DeliveryMen.Update(deliveryMan);
                    int affected = await _db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return deliveryMan;
                    }
                    return null;
                }
            }
            catch 
            {
                return null;
            }

        }
    }
}

