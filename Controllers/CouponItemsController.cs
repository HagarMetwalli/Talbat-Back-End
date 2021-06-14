using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponItemsController : ControllerBase
    {
        private IGenericComposite<CouponItem> repo;

        public CouponItemsController(IGenericComposite<CouponItem> repo)
        {
            this.repo = repo;
        }


        // GET: api/CouponItems
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<CouponItem>>))]
        public ActionResult<List<CouponItem>> Get()
        {
            var rels = repo.RetriveAll();
            if (rels.Count == 0)
            {
                return NoContent();
            }

            return Ok(rels);
        }

        // GET api/CouponItems/5/2
        [HttpGet("{id1}/{id2}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<CouponItem>))]
        public ActionResult<CouponItem> Get(int id1, int id2)
        {
            if (id1 <= 0 || id2 <= 0)
            {
                return BadRequest();
            }

            var rel = repo.Retrive(id1, id2);
            if (rel == null)
            {
                return NotFound();
            }

            return Ok(rel);
        }

        // GET api/CouponItems/GetByCouponnId/5
        [HttpGet]
        [Route("GetByCouponnId/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<CouponItem>>))]
        public ActionResult<CouponItem> GetByCouponnId(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var rel = repo.RetriveWithFstKey(id);
            if (rel == null)
            {
                return NotFound();
            }

            return Ok(rel);
        }

        // GET api/CouponItems/GetByItemId/5
        [HttpGet]
        [Route("GetByItemId/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<CouponItem>>))]
        public ActionResult<CouponItem> GetByItemId(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var rel = repo.RetriveWithSndKey(id);
            if (rel == null)
            {
                return NotFound();
            }

            return Ok(rel);
        }

        // POST api/CouponItems
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<CouponItem> Post([FromBody] CouponItem promotionItem)
        {
            if (promotionItem == null || promotionItem.CouponId < 0 || promotionItem.ItemId < 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var added = repo.Create(promotionItem);
            if (added == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/CouponItems/5
        [HttpDelete]
        [Route("{id1}/{id2}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id1, int id2)
        {
            if (id1 <= 0 || id2 <= 0)
            {
                return BadRequest();
            }

            bool deleted = repo.Delete(id1, id2);
            if (!deleted)
            {
                return BadRequest($"Delete Failed, Please recheck keys entered!");
            }

            return NoContent();

        }

        // Put api/CouponItems/promotionId:5/ItemId:2
        [HttpPut]
        [Route("{id1}/{id2}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id1, int id2, [FromBody] CouponItem rel)
        {
            if (rel == null || rel.CouponId <= 0 || rel.ItemId <= 0 || rel.CouponId != id1 || rel.ItemId != id2)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modified = repo.Put(rel);
            if (modified == null)
            {
                return BadRequest("Failed to Update!");
            }

            return NoContent();
        }
    }
}
