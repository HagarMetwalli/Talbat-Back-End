using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talbat.IServices
{
    public interface IReview<T> : IGeneric<T> 
    {
        public bool IfHaveReview(int id);
    }
}
