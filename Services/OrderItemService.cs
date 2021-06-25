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

        public List<Item> RetriveByOrderIdAsync(int orderId)
        {
            var orderItems = db.OrderItems.Where(
                x => x.OrderId == orderId)
                .ToList()
                .Join(
                    db.Items,
                    oi => oi.ItemId,
                    i => i.ItemId,
                    (orit, it) => it
                )
                .ToList();

            if (orderItems.Count== 0)
            {
                return null;
            }

            return orderItems;
        }

        public List<OrderItem> CreateListAsync(List<OrderItem> itemsList,int orderid)
        {
            try
            {
                itemsList.ForEach(item => item.OrderId = orderid);
                db.OrderItems.AddRange(itemsList);
                db.SaveChanges();
                return itemsList;


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

        //Task<OrderItem> IGeneric<OrderItem>.PatchAsync(OrderItem item)
        //{
        //    try
        //        {
        //            db.OrderItems.Update(item);

        //            int affected = db.SaveChanges();
        //            if (affected == 1)
        //            {
        //            return Task<OrderItem>.Run<OrderItem>(item);
        //        }

        //            return null;
        //        }
        //        catch (System.Exception)
        //        {
        //            return null;
        //        }
        //    }

        List<OrderItem> IOrderItems.PatchListAsync(List<OrderItem> itemsList)
        {
            try
            {
                var orderItemsCurrentList = db.OrderItems.Where(x => x.OrderId == itemsList[0].OrderId).ToList();

                var listsEqualityTest = Enumerable.SequenceEqual(orderItemsCurrentList, itemsList);

                if (listsEqualityTest == true)
                {
                    return itemsList;
                }

                //db.OrderItems.ToList().RemoveAll(x => x.OrderId == itemsList[0].OrderId);
                //var x = db.OrderItems.Where(x => x.OrderId == itemsList[0].OrderId).ToList();
                foreach (var oItem in orderItemsCurrentList)
                {
                    db.OrderItems.Remove(oItem);
                }

                //foreach (var item in itemsList)
                //{
                //    db.OrderItems.Add(item);
                //}

                //db.OrderItems.AddRange(itemsList);

                int affected = db.SaveChanges();
                if (affected >= 1)
                {
                    using (var dbb= new TalabatContext())
                    {
                        foreach (var item in itemsList)
                        {
                            dbb.OrderItems.Add(item);
                        }

                        int affectedd = dbb.SaveChanges();
                        if (affectedd >= 1)
                        {
                            return itemsList;
                        }

                        return null;
                    }
                    
                    //var x = blabla.AddOrderItemsAsync(itemsList);
                    //if (x == 1)
                    //{

                    //}
                }

                return null;
            }
            catch (System.Exception)
            {
                return null;
            }
            //catch (System.Exception)
            //{
            //    throw;
            //}    

        }
        
        public Task<OrderItem> PatchAsync(OrderItem item)
        {
            throw new System.NotImplementedException();
        }
    }//end class

    //abstract class blabla
    //{

    //    public static async Task<int> AddOrderItemsAsync(List<OrderItem> itemslist)
    //    {
    //        using (var db = new TalabatContext())
    //        {
    //            foreach (var item in itemslist)
    //            {
    //                db.OrderItems.Add(item);
    //            }

    //            int affectedd = await db.SaveChangesAsync();
    //            if (affectedd >= 1)
    //            {
    //                return 1;
    //            }
    //            return 0;
    //        }
    //    }
    //}
}



// TODO: Fix all Task blabla things ,,, no need for these wierdo staff!