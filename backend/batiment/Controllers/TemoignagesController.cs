using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BatimentsApi.Models;
using batiment.Models;

namespace batiment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemoignagesController : ControllerBase
    {
        private readonly BatimentContext _context;

        public TemoignagesController(BatimentContext context)
        {
            _context = context;
        }

        // GET: api/Temoignages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Temoignage>>> GetTemoignages()
        {
            return await _context.Temoignages.ToListAsync();
        }

        // GET: api/Temoignages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Temoignage>> GetTemoignage(int id)
        {
            var temoignage = await _context.Temoignages.FindAsync(id);

            if (temoignage == null)
            {
                return NotFound();
            }

            return temoignage;
        }

        // PUT: api/Temoignages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemoignage(int id, Temoignage temoignage)
        {
            if (id != temoignage.Id)
            {
                return BadRequest();
            }

            _context.Entry(temoignage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemoignageExists(id))
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

        // POST: api/Temoignages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Temoignage>> PostTemoignage(Temoignage temoignage)
        {
            _context.Temoignages.Add(temoignage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTemoignage), new { id = temoignage.Id }, temoignage);
        }

        // DELETE: api/Temoignages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemoignage(int id)
        {
            var temoignage = await _context.Temoignages.FindAsync(id);
            if (temoignage == null)
            {
                return NotFound();
            }

            _context.Temoignages.Remove(temoignage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TemoignageExists(int id)
        {
            return _context.Temoignages.Any(e => e.Id == id);
        }
    }
}
