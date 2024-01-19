using AirportAPI.Data;
using AirportAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly AirportContext _context;

        public AircraftController(AirportContext context)
        {
            _context = context;
        }

        // GET: api/Aircraft
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aircraft>>> GetAircrafts()
        {
            if (_context.Aircrafts == null)
            {
                return NotFound();
            }
            return await _context.Aircrafts.ToListAsync();
        }

        // GET: api/Aircraft/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aircraft>> GetAircraft(int id)
        {
            if (_context.Aircrafts == null)
            {
                return NotFound();
            }
            var aircraft = await _context.Aircrafts.FindAsync(id);

            if (aircraft == null)
            {
                return NotFound();
            }

            return aircraft;
        }

        // PUT: api/Aircraft/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAircraft(int id, Aircraft aircraft)
        {
            if (id != aircraft.Id)
            {
                return BadRequest();
            }

            _context.Entry(aircraft).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftExists(id))
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

        // POST: api/Aircraft
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aircraft>> PostAircraft(Aircraft aircraft)
        {
            if (_context.Aircrafts == null)
            {
                return Problem("Entity set 'AirportContext.Aircrafts'  is null.");
            }
            _context.Aircrafts.Add(aircraft);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAircraft", new { id = aircraft.Id }, aircraft);
        }

        // DELETE: api/Aircraft/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAircraft(int id)
        {
            if (_context.Aircrafts == null)
            {
                return NotFound();
            }
            var aircraft = await _context.Aircrafts.FindAsync(id);
            if (aircraft == null)
            {
                return NotFound();
            }

            _context.Aircrafts.Remove(aircraft);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AircraftExists(int id)
        {
            return (_context.Aircrafts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
