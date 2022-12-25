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
    public class TimeOfProductionsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public TimeOfProductionsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: TimeOfProductions
        public async Task<IActionResult> Index()
        {
              return View(await _context.TimeOfProduction.ToListAsync());
        }

        // GET: TimeOfProductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TimeOfProduction == null)
            {
                return NotFound();
            }

            var timeOfProduction = await _context.TimeOfProduction
                .FirstOrDefaultAsync(m => m.TimeOfProductionId == id);
            if (timeOfProduction == null)
            {
                return NotFound();
            }

            return View(timeOfProduction);
        }

        // GET: TimeOfProductions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeOfProductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeOfProductionId,CarConfigId,Time")] TimeOfProduction timeOfProduction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeOfProduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeOfProduction);
        }

        // GET: TimeOfProductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TimeOfProduction == null)
            {
                return NotFound();
            }

            var timeOfProduction = await _context.TimeOfProduction.FindAsync(id);
            if (timeOfProduction == null)
            {
                return NotFound();
            }
            return View(timeOfProduction);
        }

        // POST: TimeOfProductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeOfProductionId,CarConfigId,Time")] TimeOfProduction timeOfProduction)
        {
            if (id != timeOfProduction.TimeOfProductionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeOfProduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeOfProductionExists(timeOfProduction.TimeOfProductionId))
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
            return View(timeOfProduction);
        }

        // GET: TimeOfProductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TimeOfProduction == null)
            {
                return NotFound();
            }

            var timeOfProduction = await _context.TimeOfProduction
                .FirstOrDefaultAsync(m => m.TimeOfProductionId == id);
            if (timeOfProduction == null)
            {
                return NotFound();
            }

            return View(timeOfProduction);
        }

        // POST: TimeOfProductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TimeOfProduction == null)
            {
                return Problem("Entity set 'CarManufactoringContext.TimeOfProduction'  is null.");
            }
            var timeOfProduction = await _context.TimeOfProduction.FindAsync(id);
            if (timeOfProduction != null)
            {
                _context.TimeOfProduction.Remove(timeOfProduction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeOfProductionExists(int id)
        {
          return _context.TimeOfProduction.Any(e => e.TimeOfProductionId == id);
        }
    }
}
