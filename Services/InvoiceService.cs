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
    public class InvoiceService : IGenericService<Invoice>
    {
        private TalabatContext _db;
        public InvoiceService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Invoice> CreatAsync(Invoice invoice)
        {
            await _db.Invoices.AddAsync(invoice);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return invoice;
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            Invoice invoice = await RetriveAsync(id);
            _db.Invoices.Remove(invoice);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public Task<IEnumerable<Invoice>> RetriveAllAsync()
        {
            return Task<IEnumerable>.Run<IEnumerable<Invoice>>(() => _db.Invoices);
        }
        public Task<Invoice> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Invoices.Find(id));
        }

        public async Task<Invoice> UpdateAsync(Invoice invoice)
        {
            _db = new TalabatContext();
            _db.Invoices.Update(invoice);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return invoice;
            return null;
        }

    }
}
