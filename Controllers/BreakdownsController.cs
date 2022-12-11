using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;

namespace CarManufactoring.Controllers
{
    public class BreakdownsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public BreakdownsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Breakdowns
        public async Task<IActionResult> Index()
        {
              return View(await _context.Breakdown.ToListAsync());
        }

        // GET: Breakdowns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Breakdown == null)
            {
                return NotFound();
            }

            var breakdown = await _context.Breakdown
                .FirstOrDefaultAsync(m => m.BreakdownId == id);
            if (breakdown == null)
            {
                return NotFound();
            }

            return View(breakdown);
        }

        // GET: Breakdowns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Breakdowns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BreakdownId,BreakdownName,BreakdownDate,BreakdownNumber,ReparationDate,MachineStop,MachineReplacement")] Breakdown breakdown)
        {
            if (ModelState.IsValid)
            {
                _context.Add(breakdown);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(breakdown);
        }

        // GET: Breakdowns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Breakdown == null)
            {
                return NotFound();
            }

            var breakdown = await _context.Breakdown.FindAsync(id);
            if (breakdown == null)
            {
                return NotFound();
            }
            return View(breakdown);
        }

        // POST: Breakdowns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BreakdownId,BreakdownName,BreakdownDate,BreakdownNumber,ReparationDate,MachineStop,MachineReplacement")] Breakdown breakdown)
        {
            if (id != breakdown.BreakdownId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breakdown);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreakdownExists(breakdown.BreakdownId))
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
            return View(breakdown);
        }

        // GET: Breakdowns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Breakdown == null)
            {
                return NotFound();
            }

            var breakdown = await _context.Breakdown
                .FirstOrDefaultAsync(m => m.BreakdownId == id);
            if (breakdown == null)
            {
                return NotFound();
            }

            return View(breakdown);
        }

        // POST: Breakdowns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Breakdown == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Breakdown'  is null.");
            }
            var breakdown = await _context.Breakdown.FindAsync(id);
            if (breakdown != null)
            {
                _context.Breakdown.Remove(breakdown);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreakdownExists(int id)
        {
          return _context.Breakdown.Any(e => e.BreakdownId == id);
        }
    }
}
