using AirportApp.Data;
using AirportApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirportApp.Controllers
{
    public class GatesController : Controller
    {
        private readonly AirportContext _context;

        public GatesController(AirportContext context)
        {
            _context = context;
        }

        // GET: Gates
        public async Task<IActionResult> Index()
        {
            return _context.Gates != null ?
                        View(await _context.Gates.ToListAsync()) :
                        Problem("Entity set 'AirportContext.Gates'  is null.");
        }

        // GET: Gates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gates == null)
            {
                return NotFound();
            }

            var gate = await _context.Gates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gate == null)
            {
                return NotFound();
            }

            return View(gate);
        }

        // GET: Gates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Gate gate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gate);
        }

        // GET: Gates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gates == null)
            {
                return NotFound();
            }

            var gate = await _context.Gates.FindAsync(id);
            if (gate == null)
            {
                return NotFound();
            }
            return View(gate);
        }

        // POST: Gates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Gate gate)
        {
            if (id != gate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GateExists(gate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gate);
        }

        // GET: Gates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gates == null)
            {
                return NotFound();
            }

            var gate = await _context.Gates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gate == null)
            {
                return NotFound();
            }

            return View(gate);
        }

        // POST: Gates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gates == null)
            {
                return Problem("Entity set 'AirportContext.Gates'  is null.");
            }
            var gate = await _context.Gates.FindAsync(id);
            if (gate != null)
            {
                _context.Gates.Remove(gate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GateExists(int id)
        {
            return (_context.Gates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
