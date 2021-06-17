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
    public class OrderReviewsController : ControllerBase
    {
        private IorderReview _repo;
        private TalabatContext _db;

        public OrderReviewsController( IorderReview repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/OrderReviews
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<OrderReview>>))]
        public async Task<ActionResult<List<OrderReview>>> Get()
        {
            List<OrderReview> orderReviews = await _repo.RetriveAllAsync();
            if (orderReviews == null)
                return BadRequest();
            if (orderReviews.Count == 0)
                return NoContent();
            return Ok(orderReviews);
        }

        // GET api/OrderReviews/5
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            OrderReview OrderReview = await _repo.RetriveAsync(id);

            if (OrderReview == null)
                return NotFound();

            return Ok(OrderReview);
        }

        // POST api/OrderReviews
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] OrderReview OrderReview)
        {
            if (OrderReview == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderId = _db.Orders.Find(OrderReview.OrderId);
            if (orderId == null)
                return BadRequest();
            OrderReview added = await _repo.CreatAsync(OrderReview);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        // DELETE api/OrderReviews/5
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
                 return NotFound();
           
            bool deleted = await _repo.DeleteAsync(id);
            if (deleted)
            {
                return new NoContentResult();
            }
            else
            {
                return BadRequest($"OrderReview {id} was found but failed to delete");
            }
        }
        // Patch api/ OrderReviews/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Patch(int id, [FromBody] OrderReview OrderReview)
        {
            if (OrderReview == null|| OrderReview.OrderReviewId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderId = _db.Orders.Find(OrderReview.OrderId);
            if (orderId == null )
            {
                return BadRequest();
            }
            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            var affected = await _repo.PatchAsync(OrderReview);
            if (affected == null)
            {
                return BadRequest();
            }
            return new NoContentResult();

        }

        // POST api/allStoreReview
        [HttpGet]
        [Route("allStoreReview/{storeid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> allStoreReview(int storeid)
        {
            if (storeid <= 0)
            {
                return BadRequest();
            }
            var reviwes = await _repo.ALLCommentsForStore(storeid);
            if (reviwes == null)
                return NotFound();
            return Ok(reviwes);
        }

        
    }
}
