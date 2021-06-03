using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talbat.IServices
{
    public interface IGeneric<T>
    {
        Task<List<T>> RetriveAllAsync();
        Task<T> RetriveAsync(int id);
        Task<T> CreatAsync(T item);
        Task<bool> DeleteAsync(int id);
        Task<T> PatchAsync(T item);

    }
}
