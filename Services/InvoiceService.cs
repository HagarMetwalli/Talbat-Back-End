//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using System.Collections;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Talbat.IServices;
//using Talbat.Models;

//namespace Talbat.Services
//{
//    public class InvoiceService : IGeneric<Invoice>
//    {
//        private TalabatContext _db;
//        public InvoiceService(TalabatContext db)
//        {
//            _db = db;
//        }
//        public async Task<Invoice> CreatAsync(Invoice invoice)
//        {
//            try
//            {
//                using (var db = new TalabatContext())
//                {
//                    await _db.Invoices.AddAsync(invoice);
//                    int affected = await _db.SaveChangesAsync();
//                    if (affected == 1)
//                    {
//                        return invoice;
//                    }
//                    return null;
//                }
//            }
//            catch 
//            {
//                return null;
//            }

//        }
//        public async Task<bool> DeleteAsync(int id)
//        {
//            try
//            {
//                using (var db = new TalabatContext())
//                {
//                    Invoice invoice = await RetriveAsync(id);
//                    db.Invoices.Remove(invoice);
//                    int affected = await db.SaveChangesAsync();

//                    if (affected == 1)
//                    {
//                        return true;
//                    }
//                    return false;
//                }
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public Task<List<Invoice>> RetriveAllAsync()
//        {
//            try
//            {
//                return Task<IList>.Run<List<Invoice>>(() => _db.Invoices.ToList());
//            }
//            catch
//            {
//                return null;
//            }
//        }
//        public Task<Invoice> RetriveAsync(int id)
//        {
//            try
//            {
//                return Task.Run(() => _db.Invoices.Find(id));
//            }
//            catch 
//            {
//                return null;
//            }
//        }

//        public async Task<Invoice> PatchAsync(Invoice invoice)
//        {
 
//            try
//            {
//                using (var db = new TalabatContext())
//                {     
//                    db.Invoices.Update(invoice);
//                    int affected = await db.SaveChangesAsync();
//                    if (affected == 1)
//                    {
//                        return invoice;
//                    }
//                    return null;
//                }
//            }
//            catch
//            {
//                return null;
//            }
//        }

//    }
//}
