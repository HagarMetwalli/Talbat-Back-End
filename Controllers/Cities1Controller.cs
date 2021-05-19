using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talbat.IServices;
using Talbat.Models;
using Talbat.Services;

namespace Talbat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cities1Controller : ControllerBase
    {
        //private readonly TalabatContext _context;
        private readonly IGenericService<City> _context;
        private TalabatContext db;

        public Cities1Controller(IGenericService<City> context, TalabatContext db)
        {
            this._context = context;
            this.db = db;
        }

        // GET: api/Cities1
        [HttpGet]
        public async Task<IEnumerable<City>> GetCities()
        {
            return await _context.RetriveAllAsync();
        }

        // GET: api/Cities1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var c = await _context.RetriveAsync(id);
            if (c == null)
            {
                return NotFound();
            }
            return c;
        }

        // Patch: api/Cities1/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCity(int id, City c)
        {
            if (id != c.CityId)
            {
                return BadRequest();
            }

            //db.Entry(c).State = EntityState.Modified;
            //await db.SaveChangesAsync();

            await _context.UpdateAsync(id, c);

            return NoContent();
        }

        //try
        //{
        //}
        //catch (Exception)
        //{
        //    throw;
        //}

        // POST: api/Cities1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City c)
        {
            var cUpdated = await _context.CreatAsync(c);

            if (cUpdated == null)
            {
                return BadRequest();
            }
            return c;
        }

        // DELETE: api/Cities1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var c = await _context.RetriveAsync(id);

            if (c == null)
            {
                return NotFound();
            }

            await _context.DeleteAsync(id);

            return NoContent();
        }
    
    }
}