//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using System;
//using System.Collections;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Talbat.IServices;
//using Talbat.Models;

//namespace Talbat.Services
//{
//    public class ClientPromotionService
//    {
//        private TalabatContext _db;
//        public ClientPromotionService (TalabatContext db)
//        {
//            _db = db;
//        }
//        public async Task<ClientPromotion> CreatAsync(ClientPromotion clientPromotion)
//        {
//            await _db.ClientPromotions.AddAsync(clientPromotion);
//            int affected = await _db.SaveChangesAsync();
//            if (affected == 1)
//                return clientPromotion;
//            return null;
//        }
//        public async Task<bool?> DeleteAsync(int id)
//        {
//            ClientPromotion clientPromotion = await RetriveAsync(id);
//            _db.ClientPromotions.Remove(clientPromotion);
//            int affected = await _db.SaveChangesAsync();
//            if (affected == 1)
//                return true;
//            return null;
//        }
//        public Task<IList<ClientPromotion>> RetriveAllAsync()
//        {
//            return Task<IList>.Run<IList<ClientPromotion>>(() => _db.ClientPromotions.ToList());
//        }
//        public Task<ClientPromotion> RetriveAsync(int id)
//        {
//            return Task.Run(() => _db.ClientPromotions.Find(id));
//        }
//        public async Task<ClientPromotion> UpdateAsync(ClientPromotion clientPromotion)
//        {
//            _db = new TalabatContext();
//            _db.ClientPromotions.Update(clientPromotion);
//            int affected = await _db.SaveChangesAsync();
//            if (affected == 1)
//                return clientPromotion;
//            return null;
//        }

//    }
//}
