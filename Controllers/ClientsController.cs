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
        private IClientService _repo;

        public ClientsController(IClientService repo)
        {
            _repo = repo;
        }

        // GET: api/clients
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<IList<Client>>))]
        public async Task<ActionResult<IList<Client>>> Get()
        {
            IList<Client> clients = await _repo.RetriveAllAsync();
            if (clients.Count == 0)
                return NoContent();
            return Ok(clients);
        }

        // GET api/clients/5
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            Client client = await _repo.RetriveAsync(id);
            string token = Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token) || client == null)
                return BadRequest();
            
            var tok = token.Replace("Bearer ", "");
            var jwttoken = new JwtSecurityTokenHandler().ReadJwtToken(tok);
            var jti = jwttoken.Claims.First(claim => claim.Type == ClaimTypes.Email);
            if (client.ClientEmail != jti.Value)       
                    return Unauthorized();
            return Ok(client);
        }

        // POST api/clients
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            if (client == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Client added = await _repo.CreatAsync(client);
            if (added == null)
                return BadRequest();

            return Ok();
        }

        //Patch api/clients/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<City>> PatchClient(int id, [FromBody] Client client)
        {
            if (client == null || client.ClientId!=id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            var _client = await _repo.UpdateAsync(client);
            if (_client == null)
                return BadRequest();

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
            bool? deleted = await _repo.DeleteAsync(id);
            if (deleted.HasValue && deleted.Value)
            {
                return new NoContentResult();//204 No Content
            }
            else
            {
                return BadRequest($"client {id} was found but failed to delete");
            }
        }
        // POST api/clients/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login([FromBody] LoginService obj)
        {
            if (obj.Email== null || obj.Password == null)
                return BadRequest();
            var token =await  _repo.Login(obj); 

            if (token == null)
                return Unauthorized();

            return Ok(new {Token = token});
        }
    }
}
