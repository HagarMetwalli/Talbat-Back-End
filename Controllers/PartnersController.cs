
﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : ControllerBase
    {
        private IUserService<Partner> _repo;
        private TalabatContext _db;

        public PartnersController(IUserService<Partner> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/Partners
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Partner>>))]
        public async Task<ActionResult<List<Partner>>> Get()
        {
            List<Partner> partners = await _repo.RetriveAllAsync();
            if (partners == null)
                return BadRequest();
            if (partners.Count == 0)
                return NoContent();
            return Ok(partners);
        }
        // GET: api/clients/GetClientCount
        [HttpGet]
        [Route("GetPartnerCount")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<int>))]
        public async Task<ActionResult<List<Client>>> GetPartnerCount()
        {
            int count = await _repo.RetriveCount();
            if (count == 0)
            {
                return NotFound();
            }
            return Ok(count);
        }

        // GET api/Partners/5
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();
            Partner Partner = await _repo.RetriveAsync(id);
            if (Partner == null)
                return NotFound();
            return Ok(Partner);
        }

        // POST api/Partners
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Partner Partner)
        {
            if (Partner == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var StoreId = _db.Stores.Find(Partner.StoreId);

            if (StoreId == null)
                return BadRequest();

            Partner.PartnerEmail = Partner.PartnerEmail.ToLower();

            Partner _partner = await _repo.RetriveByEmail(Partner.PartnerEmail);

            if (_partner != null)
            {
                return BadRequest("The Email is already exist");
            }

            Partner added = await _repo.CreatAsync(Partner);
            if (added == null)
                return BadRequest();

            return Ok();
        }

        // DELETE api/Partners/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var existing = await _repo.RetriveAsync(id);

            if (existing == null)
            {
                return NotFound();
            }
            bool deleted = await _repo.DeleteAsync(id);
            if (deleted)
            {
                return new NoContentResult();
            }
            else
            {
                return BadRequest($"Partner {id} was found but failed to delete");
            }
        }
        // Patch api/ Partners/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> PatchPartner(int id, [FromBody] Partner Partner)
        {
            if (Partner == null || Partner.PartnerId != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var StoreId = _db.Stores.Find(Partner.StoreId);
            if (StoreId == null)
            {
                return BadRequest();
            }

            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            Partner.PartnerEmail = Partner.PartnerEmail.ToLower();

            Partner _partner = await _repo.RetriveByEmail(Partner.PartnerEmail);

            if (_partner != null)
            {
                return BadRequest("The Email is already exist");
            }

            var affected = await _repo.PatchAsync(Partner);
            if (affected == null)
            {
                return BadRequest();
            }
            return new NoContentResult();

        }

        // GET: api/partners/email
        [HttpGet]
        [Route("GetpartnerByEmail/{email}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(Partner))]
        public async Task<IActionResult> GetpartnerByEmail(string email)
        {
            if (email == null)
            {
                return BadRequest();
            }
            var partner = await _repo.RetriveByEmail(email);
            if (partner == null)
            {
                return NotFound();
            }
            return Ok(partner);
        }

        // POST api/partners/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login([FromBody] Login obj)
        {
            if (obj.Email == null || obj.Password == null)
            {
                return BadRequest();
            }
            try
            {
                var token = await _repo.Login(obj);

                if (token == null)
                {
                    return Unauthorized();
                }

                return Ok(new { Token = token });

            }
            catch
            {
                return Unauthorized();
            }
        }
        //// POST api/Partners
        [HttpPost]
        [Route("SendEmail")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        //[FromBody]
        //Email email
        public async Task<IActionResult> SendEmail()
        {
            //if (email == null)
            //{
            //    return BadRequest();
            //}
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            // var tempPartner = _db.TempPartnerRegisterationDetails.Single(p => p.TempPartnerStoreId == email.Id);

            //if (tempPartner == null)
            //{
            //    return BadRequest();

            //}
            //if (tempPartner.PartnerEmail != email.To.ToLower())
            //{
            //    return NotFound();
            //}
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

            //var sending = _repo.SendEmail();

            //if (sending != null)
            //{
            //    return BadRequest("The Email Not Send");
            //}
            return Ok();
        }

    }
}
