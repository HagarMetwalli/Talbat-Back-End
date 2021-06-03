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
    public class OrderService : IGeneric<Order>
    {
        //private TalabatContext _db;
        //public OrderService(TalabatContext db)
        //{
        //    _db = db;
        //}

        public Task<List<Order>> RetriveAllAsync()
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    var orders = db.Orders.ToList();
                    return Task.Run(() => orders);
                }
                catch (System.Exception)
                {

                    return null;
                }
            }
        }

        public Task<Order> RetriveAsync(int id)
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    var order = db.Orders.Find(id);
                    return Task.Run(() => order);
                }
                catch (System.Exception)
                {

                    return null;
                }
            }
        }

        public async Task<Order> CreatAsync(Order order)
        {
            using (var db = new TalabatContext())
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
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    Order order = await RetriveAsync(id);
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
        }

        public async Task<Order> PatchAsync(Order order)
        {
            using(var db= new TalabatContext())
            {
                try
                {
                    db.Orders.Update(order);

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
}
