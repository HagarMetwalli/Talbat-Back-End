using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IClientService : IGenericService<Client>
    {
        public Task<string> Login(LoginService obj);
    }
}
