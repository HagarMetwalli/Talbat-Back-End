using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class ClientOfferService
    {
        private TalabatContext _db;
        public ClientOfferService (TalabatContext db)
        {
            _db = db;
        }
        public async Task<ClientOffer> CreatAsync(ClientOffer clientOffer)
        {
            await _db.ClientOffers.AddAsync(clientOffer);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return clientOffer;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            ClientOffer clientOffer = await RetriveAsync(id);
            _db.ClientOffers.Remove(clientOffer);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }
        public Task<IList<ClientOffer>> RetriveAllAsync()
        {
            return Task<IList>.Run<IList<ClientOffer>>(() => _db.ClientOffers.ToList());
        }
        public Task<ClientOffer> RetriveAsync(int id)
        {
            return Task.Run(() => _db.ClientOffers.Find(id));
        }
        public async Task<ClientOffer> UpdateAsync(ClientOffer clientOffer)
        {
            _db = new TalabatContext();
            _db.ClientOffers.Update(clientOffer);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return clientOffer;
            return null;
        }

    }
}
