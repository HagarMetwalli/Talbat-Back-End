using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IGenericService<T>
    {
        Task<IEnumerable<T>> RetriveAllAsync();
        Task<T> RetriveAsync(int id);
        Task<T> CreatAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool?> DeleteAsync(int id);
    }
}
