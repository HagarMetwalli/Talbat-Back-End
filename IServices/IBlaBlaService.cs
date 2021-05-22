using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IBlaBlaService<T>
    {
        Task<List<T>> RetriveAllAsync();
        Task<T> RetriveAsync(int id);
        Task<T> CreatAsync(T item);
        Task<T> PatchAsync(T item);
        Task<bool> DeleteAsync(int id);

    }
}
