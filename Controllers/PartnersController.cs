using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var token = await _repo.Login(obj);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }
    }
}
