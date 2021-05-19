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
        private IGenericService<TempPartnerRegisterationDetail> _repo;

        public TempPartnerRegisterationDetailsController(IGenericService<TempPartnerRegisterationDetail> repo)
        {
            _repo = repo;
        }

        // GET: api/TempPartnerRegisterationDetails
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TempPartnerRegisterationDetail>))]
        public async Task<IEnumerable<TempPartnerRegisterationDetail>> Get() => await _repo.RetriveAllAsync();

        // GET api/TempPartnerRegisterationDetails/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
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
            var _client = await _repo.UpdateAsync(TempPartnerRegisterationDetail);
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
                return BadRequest($"TempPartnerRegisterationDetails {id} was found but failed to delete");
            }
        }
    }
}
