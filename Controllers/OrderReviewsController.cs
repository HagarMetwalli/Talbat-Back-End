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
        private IGenericService<OrderReview> _repo;
        private TalabatContext _db;

        public OrderReviewsController(IGenericService<OrderReview> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/OrderReviews
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderReview>))]
        public async Task<IEnumerable<OrderReview>> Get() => await _repo.RetriveAllAsync();

        // GET api/OrderReviews/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
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
            var orderId = _db.Orders.Find(OrderReview.OrderId);

            if (OrderReview == null || orderId == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            OrderReview added = await _repo.CreatAsync(OrderReview);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/OrderReviews/5
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
                return BadRequest($"OrderReview {id} was found but failed to delete");
            }
        }
        // Patch api/ OrderReviews/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> PatchOrderReview(int id, [FromBody] OrderReview OrderReview)
        {
            var orderId = _db.Orders.Find(OrderReview.OrderId);
            if (OrderReview == null || orderId == null || OrderReview.OrderReviewId != id)
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
            await _repo.UpdateAsync(OrderReview);
            return new NoContentResult();

        }
    }
}
