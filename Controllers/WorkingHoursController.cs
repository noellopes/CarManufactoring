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
    public class WorkingHoursController : Controller
    {
        private readonly CarManufactoringContext _context;

        public WorkingHoursController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: WorkingHours
        public async Task<IActionResult> Index()
        {
              return View(await _context.WorkingHours.ToListAsync());
        }

        // GET: WorkingHours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkingHours == null)
            {
                return NotFound();
            }

            var workingHours = await _context.WorkingHours
                .FirstOrDefaultAsync(m => m.WorkingHoursId == id);
            if (workingHours == null)
            {
                return NotFound();
            }

            return View(workingHours);
        }

        // GET: WorkingHours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkingHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkingHoursId,WorkerName,CheckIn,CheckOut")] WorkingHours workingHours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workingHours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workingHours);
        }

        // GET: WorkingHours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkingHours == null)
            {
                return NotFound();
            }

            var workingHours = await _context.WorkingHours.FindAsync(id);
            if (workingHours == null)
            {
                return NotFound();
            }
            return View(workingHours);
        }

        // POST: WorkingHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkingHoursId,WorkerName,CheckIn,CheckOut")] WorkingHours workingHours)
        {
            if (id != workingHours.WorkingHoursId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workingHours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkingHoursExists(workingHours.WorkingHoursId))
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
            return View(workingHours);
        }

        // GET: WorkingHours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkingHours == null)
            {
                return NotFound();
            }

            var workingHours = await _context.WorkingHours
                .FirstOrDefaultAsync(m => m.WorkingHoursId == id);
            if (workingHours == null)
            {
                return NotFound();
            }

            return View(workingHours);
        }

        // POST: WorkingHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkingHours == null)
            {
                return Problem("Entity set 'CarManufactoringContext.WorkingHours'  is null.");
            }
            var workingHours = await _context.WorkingHours.FindAsync(id);
            if (workingHours != null)
            {
                _context.WorkingHours.Remove(workingHours);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkingHoursExists(int id)
        {
          return _context.WorkingHours.Any(e => e.WorkingHoursId == id);
        }
    }
}
