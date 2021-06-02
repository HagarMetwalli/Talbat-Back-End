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
    public class TempPartnerRegisterationDetailsController : ControllerBase
    {
        private IGeneric<TempPartnerRegisterationDetail> _repo;

        public TempPartnerRegisterationDetailsController(IGeneric<TempPartnerRegisterationDetail> repo)
        {
            _repo = repo;
        }

        // GET: api/TempPartnerRegisterationDetails
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<IList<TempPartnerRegisterationDetail>>))]
        [ProducesResponseType(400)]

        public async Task<ActionResult<List<TempPartnerRegisterationDetail>>> Get()
        {
            List<TempPartnerRegisterationDetail> tempPartnerRegisterationDetails = await _repo.RetriveAllAsync();
            if (tempPartnerRegisterationDetails == null)
            {
                return BadRequest();
            }
            if (tempPartnerRegisterationDetails.Count == 0)
                return NoContent();
            return Ok(tempPartnerRegisterationDetails);
        }
        // GET api/TempPartnerRegisterationDetails/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            TempPartnerRegisterationDetail TempPartnerRegisterationDetail = await _repo.RetriveAsync(id);
            if (TempPartnerRegisterationDetail == null)
                return NotFound();
            return Ok(TempPartnerRegisterationDetail);
        }

        // POST api/TempPartnerRegisterationDetails
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] TempPartnerRegisterationDetail TempPartnerRegisterationDetail)
        {
            if (TempPartnerRegisterationDetail == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TempPartnerRegisterationDetail added = await _repo.CreatAsync(TempPartnerRegisterationDetail);
            if (added == null)
                return BadRequest();

            return Ok();
        }

        //Patch api/TempPartnerRegisterationDetails/5
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TempPartnerRegisterationDetail>> PatchTempPartnerRegisterationDetail(int id, [FromBody] TempPartnerRegisterationDetail TempPartnerRegisterationDetail)
        {
            if (TempPartnerRegisterationDetail == null || TempPartnerRegisterationDetail.TempPartnerStoreId != id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            var _client = await _repo.PatchAsync(TempPartnerRegisterationDetail);
            if (_client == null)
                return BadRequest();

            return new NoContentResult();
        }
        // DELETE api/TempPartnerRegisterationDetails/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return null;
            var existing = await _repo.RetriveAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            bool deleted = await _repo.DeleteAsync(id);
            if (deleted)
            {
                return new NoContentResult();//204 No Content
            }
            else
            {
                return BadRequest($"TempPartnerRegisterationDetails {id} was found but failed to delete");
            }
        }
    }
}
