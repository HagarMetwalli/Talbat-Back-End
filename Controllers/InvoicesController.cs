using Microsoft.AspNetCore.Http;
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
    public class InvoicesController : ControllerBase
    {
        private IGeneric<Invoice> _repo;
        private TalabatContext _db;

        public InvoicesController(IGeneric<Invoice> repo , TalabatContext db) 
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/Invoices
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Invoice>>))]
        public async Task<ActionResult<List<Client>>> Get()
        {
            List<Invoice> invoices = await _repo.RetriveAllAsync();
            if (invoices.Count == 0)
            {
                return NoContent();
            }
            if(invoices == null)
            {
                return BadRequest();
            }
            return Ok(invoices);
        }

        // GET api/Invoices/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            Invoice invoice = await _repo.RetriveAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        // POST api/Invoices
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Invoice invoice)
        {
            var orderId = _db.Orders.Find(invoice.OrderId);

            if (invoice == null || orderId == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Invoice added = await _repo.CreatAsync(invoice);
            if (added == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE api/Invoices/5
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
                return BadRequest($"invoice {id} was found but failed to delete");
            }
        }

        // Patch api/ Invoices/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Patch(int id, [FromBody] Invoice invoice)
        {
            var orderId = _db.Orders.Find(invoice.OrderId);
            if (invoice == null || orderId ==null || invoice.InvoiceId != id)
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
            await _repo.PatchAsync(invoice);
            return new NoContentResult();

        }
    }
}