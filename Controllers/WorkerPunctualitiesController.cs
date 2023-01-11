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
    public class WorkerPunctualitiesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public WorkerPunctualitiesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: WorkerPunctualities
        public async Task<IActionResult> Index()
        {
              return View(await _context.WorkerPunctuality.ToListAsync());
        }

        // GET: WorkerPunctualities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkerPunctuality == null)
            {
                return NotFound();
            }

            var workerPunctuality = await _context.WorkerPunctuality
                .FirstOrDefaultAsync(m => m.WorkerPunctualityId == id);
            if (workerPunctuality == null)
            {
                return NotFound();
            }

            return View(workerPunctuality);
        }

        // GET: WorkerPunctualities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkerPunctualities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkerPunctualityId,Name,ScheduledDate,MissedHoursLastWeek,LateShiftsLastWeek")] WorkerPunctuality workerPunctuality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workerPunctuality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workerPunctuality);
        }

        // GET: WorkerPunctualities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkerPunctuality == null)
            {
                return NotFound();
            }

            var workerPunctuality = await _context.WorkerPunctuality.FindAsync(id);
            if (workerPunctuality == null)
            {
                return NotFound();
            }
            return View(workerPunctuality);
        }

        // POST: WorkerPunctualities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkerPunctualityId,Name,ScheduledDate,MissedHoursLastWeek,LateShiftsLastWeek")] WorkerPunctuality workerPunctuality)
        {
            if (id != workerPunctuality.WorkerPunctualityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workerPunctuality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerPunctualityExists(workerPunctuality.WorkerPunctualityId))
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
            return View(workerPunctuality);
        }

        // GET: WorkerPunctualities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkerPunctuality == null)
            {
                return NotFound();
            }

            var workerPunctuality = await _context.WorkerPunctuality
                .FirstOrDefaultAsync(m => m.WorkerPunctualityId == id);
            if (workerPunctuality == null)
            {
                return NotFound();
            }

            return View(workerPunctuality);
        }

        // POST: WorkerPunctualities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkerPunctuality == null)
            {
                return Problem("Entity set 'CarManufactoringContext.WorkerPunctuality'  is null.");
            }
            var workerPunctuality = await _context.WorkerPunctuality.FindAsync(id);
            if (workerPunctuality != null)
            {
                _context.WorkerPunctuality.Remove(workerPunctuality);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerPunctualityExists(int id)
        {
          return _context.WorkerPunctuality.Any(e => e.WorkerPunctualityId == id);
        }
    }
}
