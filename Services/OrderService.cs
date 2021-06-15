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
    public class OrderService : IOrderRelated
    {
        private TalabatContext db;
        public OrderService(TalabatContext db)
        {
            this.db = db;
        }

        public List<Order> RetriveAllAsync()
        {

                try
                {
                    var orders = db.Orders.ToList();
                    return orders;
                }
                catch (System.Exception)
                {

                    return null;
                }
        }

        public Order RetriveAsync(int id)
        {

                try
                {
                    var order = db.Orders.Find(id);
                    return  order;
                }
                catch (System.Exception)
                {

                    return null;
                }
        }

        public List<Order> RetriveByClientIdAsync(int clientId)
        {
            try
            {
                var orderList = db.Orders.Where(x => x.ClientId == clientId).ToList();
                return orderList;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public async Task<Order> CreatAsync(Order order)
        {

                try
                {
                    await db.Orders.AddAsync(order);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        var store = db.Stores.Find(order.StoreId);
                        store.StoreOrdersNumber += 1;
                        return order;
                    }

                    return null;
                }
                catch (System.Exception)
                {

                    return null;
                }
        }

        public async Task<bool> DeleteAsync(int id)
        {

                try
                {
                    Order order = RetriveAsync(id);
                    db.Orders.Remove(order);

                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        var store = db.Stores.Find(order.StoreId);
                        store.StoreOrdersNumber -= 1;
                        return true;
                    }

                    return false;
                }
                catch (System.Exception)
                {
                    return false;
                }
        }

        public async Task<Order> PatchAsync(Order order)
        {

                try
                {

                if (order == db.Orders.Find(order.OrderId))
                {
                    return order;
                }

                //db.Orders.Update(order);
                db.Entry(db.Orders.FirstOrDefault(x => x.OrderId == order.OrderId)).CurrentValues.SetValues(order);


                int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return order;
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
