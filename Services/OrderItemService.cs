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
    public class OrderItemService : IOrderItems
    {
        private TalabatContext db;
        public OrderItemService(TalabatContext db)
        {
            this.db = db;
        }

        public Task<List<OrderItem>> RetriveAllAsync()
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    var orderItems = db.OrderItems.ToList();
                    return Task.Run(() => orderItems);
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public Task<OrderItem> RetriveAsync(int id)
        {
            using (var db = new TalabatContext())
            {
                try
                {
                    var orderItem = db.OrderItems.Find(id);
                    return Task.Run(() => orderItem);
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public async Task<OrderItem> CreatAsync(OrderItem orderItem)
        {
                try
                {
                    await db.OrderItems.AddAsync(orderItem);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return orderItem;
                    }

                    return null;
                }
                catch (System.Exception)
                {
                    return null;
                }
        }

        async Task<List<OrderItem>> IOrderItems.CreateListAsync(List<OrderItem> itemsList)
        {
            try
            {
                foreach (var item in itemsList)
                {
                    db.OrderItems.Add(item);
                }

                int affected = await db.SaveChangesAsync();
                if (affected >= 1)
                {
                    return itemsList;
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
            using (var db = new TalabatContext())
            {
                try
                {
                    OrderItem orderItem = await RetriveAsync(id);
                    db.OrderItems.Remove(orderItem);

                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
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

        public async Task<OrderItem> PatchAsync(OrderItem orderItem)
        {
            using(var db= new TalabatContext())
            {
                try
                {
                    db.OrderItems.Update(orderItem);

                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return orderItem;
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
