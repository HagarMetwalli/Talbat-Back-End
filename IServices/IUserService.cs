using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IUserService<T> : IGeneric<T>
    {
        public Task<T> RetriveByEmail(string Email);
        public Task<string> Login(Login obj);
        public Task<int> RetriveCount();
    }
}
