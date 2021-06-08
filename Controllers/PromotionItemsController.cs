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
    public class PromotionItemsController : ControllerBase
    {
        private IGenericComposite<PromotionItem> repo;

        public PromotionItemsController(IGenericComposite<PromotionItem> repo)
        {
            this.repo = repo;
        }


        // GET: api/PromotionItems
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<PromotionItem>>))]
        public ActionResult<List<PromotionItem>> Get()
        {
            var rels = repo.RetriveAll();
            if (rels.Count == 0)
            {
                return NoContent();
            }

            return Ok(rels);
        }

        // GET api/PromotionItems/5/2
        [HttpGet("{id1}/{id2}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<PromotionItem>))]
        public ActionResult<PromotionItem> Get(int id1, int id2)
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

        // GET api/PromotionItems/GetByOfferId/5
        [HttpGet]
        [Route("GetByEmpId/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<PromotionItem>>))]
        public ActionResult<PromotionItem> GetByOfferId(int id)
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

        // GET api/PromotionItems/GetByItemId/5
        [HttpGet]
        [Route("GetByItemId/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<PromotionItem>>))]
        public ActionResult<PromotionItem> GetByItemId(int id)
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

        // POST api/PromotionItems
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<PromotionItem> Post([FromBody] PromotionItem promotionItem)
        {
            if (promotionItem == null || promotionItem.PromotionId < 0 || promotionItem.ItemId < 0)
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

        // DELETE api/PromotionItems/5
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

        // Put api/PromotionItems/promotionId:5/ItemId:2
        [HttpPut]
        [Route("{id1}/{id2}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id1, int id2, [FromBody] PromotionItem rel)
        {
            if (rel == null || rel.PromotionId <= 0 || rel.ItemId <= 0 || rel.PromotionId != id1 || rel.ItemId != id2)
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
