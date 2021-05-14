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
    public class OrderService:IGenericService<Order>
    {
        private static ConcurrentDictionary<int, Order> OrdersCache;
        private TalabatContext db;

        public OrderService(TalabatContext db)
        {
            this.db = db;
            if (OrdersCache == null)
            {
                OrdersCache = new ConcurrentDictionary<int, Order>(
                    db.Orders.ToDictionary(o => o.OrderId));
            }
        }

        public async Task<Order> CreatAsync(Order o)
        {
            EntityEntry<Order> added = await db.Orders.AddAsync(o);
            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                return OrdersCache.AddOrUpdate(o.OrderId, o, UpdateCache);
            }

            else
            {
                return null;
            }
        }

        private Order UpdateCache(int id, Order o)
        {
            Order old;
            if (OrdersCache.TryGetValue(id, out old))
            {
                if (OrdersCache.TryUpdate(id, o, old))
                {
                    return o;
                }
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Order c = db.Orders.Find(id);

            db.Orders.Remove(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return OrdersCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Order>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<Order>>(() => OrdersCache.Values);
        // No meaning to return alll orders in the system at once without scoping by Store Orders or Client Orders!

        public Task<Order> RetriveAsync(int id)
        {
            return Task.Run(() =>
            {
                OrdersCache.TryGetValue(id, out Order c);
                return c;
            });
        }

        public async Task<Order> UpdateAsync(int id, Order c)
        {
            db.Orders.Update(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }

        public Task<Order> UpdateAsync(Order item)
        {
            throw new System.NotImplementedException();
        }
    }
}
