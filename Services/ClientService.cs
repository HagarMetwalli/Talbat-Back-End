﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;
using Talbat.Authentication;

namespace Talbat.Services
{
    public class ClientService: IUserService<Client>
    {
        TalabatContext _db = new TalabatContext();
        public ClientService(TalabatContext db)
        {
            _db = db;
        }
        public Task<List<Client>> RetriveAllAsync()
        {
            try
            {
                return Task<List<Client>>.Run<List<Client>>(() => _db.Clients.ToList());
            }
            catch 
            {
                return null;
            }
        }

        public Task<Client> RetriveAsync(int id)
        {
            try
            {
  
                return Task.Run(() => _db.Clients.Find(id));  
            }
            catch 
            {
                return null;
            }
        }
        public Task<Client> RetriveByEmail(string Email)
        {
            try
            {
                var client = _db.Clients.FirstOrDefault(c=>c.ClientEmail==Email);
                return Task<Client>.Run<Client>(() => client);
            }
            catch
            {
                return null;
            }
        }
        public async Task<Client> CreatAsync(Client client)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    client.ClientEmail.ToLower();
                    await db.Clients.AddAsync(client);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return client;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public async Task<Client> PatchAsync(Client client)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    client.ClientEmail.ToLower();
                    db.Clients.Update(client);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return client;
                    }
                    return null;
                }
            }
            catch 
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (var db = new TalabatContext())
                {
                    Client client = await RetriveAsync(id);
                    db.Clients.Remove(client);
                    int affected = await db.SaveChangesAsync();
                    if (affected == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch 
            {
                return false;
            }

        }

        public  Task<string> Login(Login obj)
        {
            try
            {
                obj.Email = obj.Email.ToLower();
                Client client = _db.Clients.FirstOrDefault(c => c.ClientEmail == obj.Email);

                Login clientLogin = _db.Logins.FirstOrDefault(x => x.Email == obj.Email && x.Password == obj.Password);

                if (client != null && clientLogin != null)
                {
                    var tokenString = UserAuthentication.CreateToken(obj.Email);
                    return Task.Run(() => tokenString);
                }
                return null;   
            }
            catch 
            {
                return null;
            }
        }
    }
}
