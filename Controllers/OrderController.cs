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
    public class OrderController : GenericController<Order>
    {
        private IGenericService<Order> repo_Order;
        //private IGenericService<Store> repo_Store;

        //private IGenericService<Client> repo_CLient;
        //IGenericService<Client> repo_client,
        //, IGenericService<Store> repo_store
        public OrderController(IGenericService<Order> repo_order) : base(repo_order)
        {
            this.repo_Order = repo_order;
            //this.repo_Store = repo_store;
            //this.repo_CLient = repo_client;
        }

        // Patch api/Order/1
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> Update(int id, [FromBody] Order o)
        {
            if (o == null || o.OrderId != id)
            {
                return BadRequest();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Order_Exist = await repo_Order.RetriveAsync(id);

            //var Store_Exist = await repo_Store.RetriveAsync(o.StoreId);
            //-no meaning to change the Client because that changes the whole order obj!-
            //var Client_Exist = await repo_Client.RetiveAsync(o.ClientId);
            //if (Order_Exist == null || Client_Exist == null)

            if (Order_Exist == null)
            {
                return NotFound();
            }

            await repo_Order.UpdateAsync(id, o);
            return new NoContentResult();

        }
    }
}
