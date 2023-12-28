using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AccSol.Data;
using AccSol.Models;

namespace AccSol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Coas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coa>>> GetCoas()
        {
            return await _context.Coas.ToListAsync();
        }

        // GET: api/Coas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coa>> GetCoa(int id)
        {
            var coa = await _context.Coas.FindAsync(id);

            if (coa == null)
            {
                return NotFound();
            }

            return coa;
        }

        // PUT: api/Coas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoa(int id, Coa coa)
        {
            if (id != coa.ID)
            {
                return BadRequest();
            }

            _context.Entry(coa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Coas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coa>> PostCoa(Coa coa)
        {
            _context.Coas.Add(coa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoa", new { id = coa.ID }, coa);
        }

        // DELETE: api/Coas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoa(int id)
        {
            var coa = await _context.Coas.FindAsync(id);
            if (coa == null)
            {
                return NotFound();
            }

            _context.Coas.Remove(coa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoaExists(int id)
        {
            return _context.Coas.Any(e => e.ID == id);
        }
    }
}
