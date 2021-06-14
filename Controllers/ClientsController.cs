using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private IUserService<Client> _repo;

        public ClientsController(IUserService <Client> repo)
        {
            _repo = repo;
        }

        // GET: api/clients
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Client>>))]
        public async Task<ActionResult<List<Client>>> Get()
        {
            List<Client> clients = await _repo.RetriveAllAsync();
            if (clients == null)
            {
                return BadRequest();
            }

            if (clients.Count == 0)
            {
                return NoContent();
            }    
            return Ok(clients);
        }

        // GET api/clients/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();                            
            }
            Client client = await _repo.RetriveAsync(id);
            if (client == null)
            {
                return BadRequest();
            }

            //string token = Request.Headers["Authorization"];

            //if (string.IsNullOrEmpty(token) || client == null)
            //{
            //    return BadRequest();
            //}

            //var jwttoken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            //var jti = jwttoken.Claims.First(claim => claim.Type == ClaimTypes.Email);
            //if (client.ClientEmail != jti.Value)
            //{
            //    return Unauthorized();
            //}
        
            return Ok(client);
        }

        // GET: api/clients/email
        [HttpGet]
        [Route("GetClientByEmail/{email}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(Client))]
        public async Task<IActionResult> GetClientByEmail(string email)
        {
            if (email == null)
            {
                return BadRequest();
            }
            var client = await _repo.RetriveByEmail(email);
            if(client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        // POST api/clients
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            client.ClientEmail = client.ClientEmail.ToLower();

            Client _client = await _repo.RetriveByEmail(client.ClientEmail);

            if(_client != null)
            {
                return BadRequest("The Email is already exist");
            }

            Client added = await _repo.CreatAsync(client);
            if (added == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        //Patch api/clients/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Client>> Patch(int id, [FromBody] Client client)
        {
            if (client == null || client.ClientId != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existing = await _repo.RetriveAsync(id);

            if (existing == null)
            {
                return NotFound();
            }
            client.ClientEmail = client.ClientEmail.ToLower();

            var _client = await _repo.RetriveByEmail(client.ClientEmail);

            if (_client != null && _client.ClientId != existing.ClientId)
            {
                return BadRequest("The Email is already exist");
            }
            var affected = _repo.PatchAsync(client);
            
            if (affected == null)
            {
                return BadRequest();
            }
            return new NoContentResult();
        }
        // DELETE api/clients/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
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
                return BadRequest($"Client {id} was found but failed to delete");
            }
        }
        // POST api/clients/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login([FromBody] Login obj)
        {
            if (obj.Email== null || obj.Password == null)
            {
                return BadRequest();
            }
            var token =await  _repo.Login(obj); 

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new {Token = token});
        }
    }
}
