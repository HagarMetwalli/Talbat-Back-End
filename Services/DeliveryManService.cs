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
    public class DeliveryManService:IGenericService<DeliveryMan>
    {
        private TalabatContext _db;
        public DeliveryManService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<DeliveryMan> CreatAsync(DeliveryMan deliveryMan)
        {
            await _db.DeliveryMen.AddAsync(deliveryMan);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return deliveryMan;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            DeliveryMan deliveryMan = await RetriveAsync(id);
            _db.DeliveryMen.Remove(deliveryMan);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IList<DeliveryMan>> RetriveAllAsync()
        {
            return Task<IList>.Run<IList<DeliveryMan>>(() => _db.DeliveryMen.ToList());
        }
        public Task<DeliveryMan> RetriveAsync(int id)
        {
            return Task.Run(() => _db.DeliveryMen.Find(id));
        }


        public async Task<DeliveryMan> UpdateAsync(DeliveryMan deliveryMan)
        {
            _db = new TalabatContext();
            _db.DeliveryMen.Update(deliveryMan);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return deliveryMan;
            return null;
        }
    }
}

