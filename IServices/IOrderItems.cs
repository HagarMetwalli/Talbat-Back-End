using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IOrderItems: IGeneric<OrderItem>
    {
        Task<List<OrderItem>> CreateListAsync(List<OrderItem> itemsList);
    }
}
