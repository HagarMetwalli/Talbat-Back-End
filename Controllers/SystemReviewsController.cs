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
    public class SystemReviewsController : ControllerBase
    {
      
        private IReview<SystemReview> _repo;
        private IUserService<Client> _db;

        public SystemReviewsController(IReview<SystemReview> repo , IUserService<Client> db)
        {
            _repo = repo;
            _db = db;

            
        }

        // GET: api/SystemReviews
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<SystemReview>>))]
        public async Task<ActionResult<List<Client>>> Get()
        {
            List<SystemReview> SystemReviews = await _repo.RetriveAllAsync();
            if (SystemReviews.Count == 0)
            {
                return NoContent();
            }
            if (SystemReviews == null)
            {
                return BadRequest();
            }
            return Ok(SystemReviews);
        }

        // GET api/SystemReviews/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            SystemReview SystemReview = await _repo.RetriveAsync(id);
            if (SystemReview == null)
            {
                return NotFound();
            }
            return Ok(SystemReview);
        }

        // POST api/SystemReviews
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] SystemReview SystemReview)
        {
            var clientid = await _db.RetriveAsync(SystemReview.ClientId);
           
            if (SystemReview == null || clientid == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exisit = _repo.IfHaveReview(SystemReview.ClientId);
            if (exisit)
            {
                return BadRequest();
            }

            SystemReview added = await _repo.CreatAsync(SystemReview);
            if (added == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE api/SystemReviews/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return null;
            }
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
                return BadRequest($"SystemReview {id} was found but failed to delete");
            }
        }

        // Patch api/ SystemReviews/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Patch(int id, [FromBody] SystemReview SystemReview)
        {
            var clientid = await _db.RetriveAsync(SystemReview.ClientId);
            if (SystemReview == null || clientid == null || SystemReview.SystemReviewId != id)
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
            var exisit = _repo.IfHaveReview(SystemReview.ClientId);
            if (!exisit)
            {
                return BadRequest();
            }
           var effected= await _repo.PatchAsync(SystemReview);
            if (effected== null)
            {
                return BadRequest();
            }
            return new NoContentResult();

        }
    }
}
