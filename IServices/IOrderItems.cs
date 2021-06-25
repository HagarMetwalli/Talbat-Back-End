using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IOrderItems: IGeneric<OrderItem>
    {
        List<OrderItem> CreateListAsync(List<OrderItem> itemsList, int orderid);
        List<OrderItem> PatchListAsync(List<OrderItem> itemsList);
        List<Item> RetriveByOrderIdAsync(int orderId);
    }
}
