using Castle.Core.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;
using System.Security.Claims;

namespace Talbat.Services
{
    public class ClientService: IClientService
    {

        private TalabatContext _db;
        public ClientService(TalabatContext db )
        {
            _db = db;
        }
        public Task<IEnumerable<Client>> RetriveAllAsync()
        {
            return Task<IEnumerable>.Run<IEnumerable<Client>>(() => _db.Clients);
        }

        public Task<Client> RetriveAsync(int id)
        {
            return Task.Run(() => _db.Clients.Find(id));
        }

        public async Task<Client> CreatAsync(Client client)
        {
            await _db.Clients.AddAsync(client);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return client;
            return null;
        }
        public async Task<Client> UpdateAsync(Client client)
        {
            _db = new TalabatContext();
            _db.Clients.Update(client);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return client;
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Client client = await RetriveAsync(id);
            _db.Clients.Remove(client);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return true;
            return null;
        }

        public  Task<string> Login(LoginService obj)
        {
            Client client = _db.Clients.FirstOrDefault(c => c.ClientEmail == obj.Email);

            if (client != null && client.ClientPassword == obj.Password)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretey@83"));
                var siginingCerdentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken
                    (
                     issuer: "https://localhost:4200",
                     audience: "https://localhost:4200",
                     claims: new List<Claim>(),
                     expires: DateTime.Now.AddMinutes(10),
                     signingCredentials: siginingCerdentials
                    ) ;
                var tokenString =  new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Task.Run(() =>tokenString);

            }
            return null;
        }
    }
}
