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
        private static ConcurrentDictionary<int, Invoice> InvoicesCache;
        private TalabatContext db;
        public InvoiceService(TalabatContext db)
        {
            this.db = db;
            if (InvoicesCache == null)
            {
                InvoicesCache = new ConcurrentDictionary<int, Invoice>(
                    db.Invoices.ToDictionary(i => i.InvoiceId));
            }
        }
        public async Task<Invoice> CreatAsync(Invoice i)
        {
            EntityEntry<Invoice> added = await db.Invoices.AddAsync(i);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return InvoicesCache.AddOrUpdate(i.InvoiceId, i, UpdateCache);
            }
            else
            {
                return null;
            }
        }
        private Invoice UpdateCache(int id, Invoice i)
        {
            Invoice old;
            if (InvoicesCache.TryGetValue(id, out old))
            {
                if (InvoicesCache.TryUpdate(id, i, old))
                {
                    return i;
                }
            }
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            Invoice c = db.Invoices.Find(id);
            db.Invoices.Remove(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return InvoicesCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Invoice>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<Invoice>>(() => InvoicesCache.Values);

        public Task<Invoice> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                InvoicesCache.TryGetValue(id, out Invoice i);
                return i;
            });
        }

        public async Task<Invoice> UpdateAsync(int id, Invoice i)
        {
            db.Invoices.Update(i);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, i);
            }
            return null;
        }

        public Task<Invoice> UpdateAsync(Invoice item)
        {
            throw new System.NotImplementedException();
        }
    }
}
