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
    public class OfferItemController : ControllerBase
    {
        private IGenericComposite<OfferItem> repo;

        public OfferItemController(IGenericComposite<OfferItem> repo)
        {
            this.repo = repo;
        }


        // GET: api/OfferItem
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<OfferItem>>))]
        public ActionResult<List<OfferItem>> Get()
        {
            var rels = repo.RetriveAll();
            if (rels.Count == 0)
            {
                return NoContent();
            }

            return Ok(rels);
        }

        // GET api/OfferItem/5/2
        [HttpGet("{id1}/{id2}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<OfferItem>))]
        public ActionResult<OfferItem> Get(int id1, int id2)
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

        // GET api/OfferItem/GetByOfferId/5
        [HttpGet]
        [Route("GetByEmpId/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<OfferItem>>))]
        public ActionResult<OfferItem> GetByOfferId(int id)
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

        // GET api/OfferItem/GetByItemId/5
        [HttpGet]
        [Route("GetByItemId/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<OfferItem>>))]
        public ActionResult<OfferItem> GetByItemId(int id)
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

        // POST api/OfferItem
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<OfferItem> Post([FromBody] OfferItem offerItem)
        {
            if (offerItem == null || offerItem.OfferId < 0 || offerItem.ItemId < 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var added = repo.Create(offerItem);
            if (added == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/OfferItem/5
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

        // Put api/OfferItem/OfferId:5/ItemId:2
        [HttpPut]
        [Route("{id1}/{id2}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id1, int id2, [FromBody] OfferItem rel)
        {
            if (rel == null || rel.OfferId <= 0 || rel.ItemId <= 0 || rel.OfferId != id1 || rel.ItemId != id2)
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
