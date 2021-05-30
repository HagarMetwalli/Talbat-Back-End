using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Models;

namespace Talbat.IServices
{
    public interface IClientService : IGeneric<Client>
    {
        public Task<Client> RetriveByEmail(string Email);
        public Task<string> Login(LoginService obj);
    }
}
