<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Mvc;
>>>>>>> Hajar
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
<<<<<<< HEAD
    public class StoreTypesController : GenericController<StoreType>
    {
        private IGenericService<StoreType> repo_StoreType;
        
        public StoreTypesController(IGenericService<StoreType> repo_StoreType) : base(repo_StoreType)
        {
            this.repo_StoreType = repo_StoreType;
        }

        // Patch api/StoreType/1
=======
    public class StoreTypesController : ControllerBase
    {
        private IGenericService<StoreType> _repo;
        private TalabatContext _db;

        public StoreTypesController(IGenericService<StoreType> repo, TalabatContext db)
        {
            _repo = repo;
            _db = db;
        }
        // GET: api/StoreTypes
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StoreType>))]
        public async Task<IEnumerable<StoreType>> Get() => await _repo.RetriveAllAsync();

        // GET api/StoreTypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetById(int id)
        {
            StoreType StoreType = await _repo.RetriveAsync(id);
            if (StoreType == null)
                return NotFound();
            return Ok(StoreType);
        }

        // POST api/StoreTypes
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] StoreType StoreType)
        {
            

            if (StoreType == null )
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StoreType added = await _repo.CreatAsync(StoreType);
            if (added == null)
                return BadRequest();
            return Ok();
        }

        // DELETE api/StoreTypes/5
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
                return BadRequest($"StoreType {id} was found but failed to delete");
            }
        }
        // Patch api/StoreTypes/5
>>>>>>> Hajar
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

<<<<<<< HEAD
        public async Task<IActionResult> Update(int id, [FromBody] StoreType o)
        {
            if (o == null || o.StoreTypeId != id)
            {
                return BadRequest();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var StoreType_Exist = await repo_StoreType.RetriveAsync(id);
        
            if (StoreType_Exist == null)
            {
                return NotFound();
            }

            await repo_StoreType.UpdateAsync(id, o);
=======
        public async Task<IActionResult> Patch(int id, [FromBody] StoreType StoreType)
        {
          
            if (StoreType == null || StoreType.StoreTypeId != id)
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
            await _repo.UpdateAsync(StoreType);
>>>>>>> Hajar
            return new NoContentResult();

        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> Hajar
