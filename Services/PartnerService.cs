using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Talbat.Authentication;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class PartnerService : IUserService<Partner>
    {
        private TalabatContext _db;
        public PartnerService(TalabatContext db)
        {
            _db = db;
        }
        public async Task<Partner> CreatAsync(Partner Partner)
        {
            try
            {
                Partner.PartnerEmail.ToLower();
                await _db.Partners.AddAsync(Partner);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return Partner;
                return null;
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
                Partner Partner = await RetriveAsync(id);
                var store = _db.Stores.Find(Partner.StoreId);
                _db.Partners.Remove(Partner);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                {
                    _db.Stores.Remove(store);
                    int affect = await _db.SaveChangesAsync();
                    if (affect== 1)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<Partner>> RetriveAllAsync()
        {
            try { 
            return Task<List<Partner>>.Run<List<Partner>>(() => _db.Partners.Include("Store").ToList());
            }
            catch
            {
                return null;
            }
        }
        public Task<Partner> RetriveAsync(int id)
        {
            try
            {
                return Task.Run(() => _db.Partners.Find(id));
            }
            catch
            {
                return null;
            }
        }

        public async Task<Partner> PatchAsync(Partner Partner)
        {
            try
            {
                _db = new TalabatContext();
                Partner.PartnerEmail.ToLower();
                _db.Partners.Update(Partner);
                int affected = await _db.SaveChangesAsync();
                if (affected == 1)
                    return Partner;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Task<string> Login(Login obj)
        {
            try
            {
                obj.Email = obj.Email.ToLower();
                Partner partner = _db.Partners.FirstOrDefault(c => c.PartnerEmail == obj.Email);

                if (partner != null && partner.PartnerPassword == obj.Password)
                {
                    var tokenString = UserAuthentication.CreateToken(obj.Email);
                    return Task.Run(() => tokenString);
                }
                return (Task<string>)Task.Run(() => null);
            }
            catch
            {
                return (Task<string>)Task.Run(() => null);
            }
        }
        public Task<Partner> RetriveByEmail(string Email)
        {
            try
            {
                var partener = _db.Partners.FirstOrDefault(c => c.PartnerEmail == Email);
                return Task<Partner>.Run<Partner>(() => partener);
            }
            catch
            {
                return null;
            }
        }

        public Task<int> RetriveCount()
        {
            try
            {

                return Task.Run(() => _db.Partners.Count());
            }
            catch
            {
                return null;
            }
        }

        public Task<string> SendEmail()
        {
            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("from_address@example.com"));
            email.To.Add(MailboxAddress.Parse("to_address@example.com"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = "<h1>Example HTML Message Body</h1>" };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("elza.schuppe@ethereal.email", "Sf3T9DkJSwF2C7Cyyp");
            smtp.Send(email);
            smtp.Disconnect(true);
            //try
            //{

            //    //Display some feedback to the user to let them know it was sent

            //}
            //catch (Exception ex)
            //{
            //    //If the message failed at some point, let the user know
            //return Task<string>.Run<string>(() => "nnn");

            //    //"Your message failed to send, please try again."
            //}

            //string to = email.To;
            //string subject = email.Subject;
            //string body = email.Body;
            //MailMessage mailMessage = new MailMessage();
            //mailMessage.To.Add(to);
            //mailMessage.Subject = subject;
            //mailMessage.Body = body;
            //mailMessage.From = new MailAddress("hagarmetwali011@gmail.com");
            //mailMessage.IsBodyHtml = false;
            //SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            //smtp.Port = 587;
            //smtp.UseDefaultCredentials = true;
            //smtp.EnableSsl = true;
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //TcpClient tcpClient = new TcpClient(AddressFamily.InterNetworkV6);
            //tcpClient.Client.DualMode = true;
            //smtp.Credentials = new System.Net.NetworkCredential("ahmed19981511@gmail.com", "ElhamdLlh");
            //smtp.Send(mailMessage);
            //return Task<string>.Run(()=>"send");

            //Create the msg object to be sent


            return Task<string>.Run<string>(() => "nnn");

            
        }
    }
}

