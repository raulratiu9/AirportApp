using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirportAPI.Models;

namespace AirportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatesController : ControllerBase
    {
        private readonly AirportContext _context;

        public GatesController(AirportContext context)
        {
            _context = context;
        }

        // GET: api/Gates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gate>>> GetGates()
        {
          if (_context.Gates == null)
          {
              return NotFound();
          }
            return await _context.Gates.ToListAsync();
        }

        // GET: api/Gates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gate>> GetGate(int id)
        {
          if (_context.Gates == null)
          {
              return NotFound();
          }
            var gate = await _context.Gates.FindAsync(id);

            if (gate == null)
            {
                return NotFound();
            }

            return gate;
        }

        // PUT: api/Gates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGate(int id, Gate gate)
        {
            if (id != gate.Id)
            {
                return BadRequest();
            }

            _context.Entry(gate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GateExists(id))
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

        // POST: api/Gates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gate>> PostGate(Gate gate)
        {
          if (_context.Gates == null)
          {
              return Problem("Entity set 'AirportContext.Gates'  is null.");
          }
            _context.Gates.Add(gate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGate", new { id = gate.Id }, gate);
        }

        // DELETE: api/Gates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGate(int id)
        {
            if (_context.Gates == null)
            {
                return NotFound();
            }
            var gate = await _context.Gates.FindAsync(id);
            if (gate == null)
            {
                return NotFound();
            }

            _context.Gates.Remove(gate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GateExists(int id)
        {
            return (_context.Gates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
