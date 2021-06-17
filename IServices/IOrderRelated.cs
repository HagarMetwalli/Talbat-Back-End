using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IOrderRelated
    {
        List<Order> RetriveAllAsync();
        Order RetriveAsync(int orderId);
        List<Order> RetriveByClientIdAsync(int clientId);

        Task<Order> CreatAsync(Order order);

        Task<bool> DeleteAsync(int id);

        Task<Order> PatchAsync(Order item);
        IEnumerable RetriveItemsInOrderdAsync(int orderId);

    }
}
