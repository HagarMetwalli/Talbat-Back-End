using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talbat.IServices
{
    public interface IGenericService<T>
    {
        Task<T> CreatAsync(T item);
        Task<IEnumerable<T>> RetriveAllAsync();
        Task<T> RetriveAsync(int id);
        Task<T> UpdateAsync(int id,T item);
        Task<bool?> DeleteAsync(int id);

    }
}
