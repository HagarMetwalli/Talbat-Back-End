using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IorderReview : IGeneric<OrderReview>
    {
        public Task<List<OrderReview>> ALLCommentsForStore(int storeid);
    }
}
