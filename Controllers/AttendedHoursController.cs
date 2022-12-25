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
    public class AttendedHoursController : Controller
    {
        private readonly CarManufactoringContext _context;

        public AttendedHoursController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: AttendedHours
        public async Task<IActionResult> Index()
        {
              return View(await _context.AttendedHours.ToListAsync());
        }

        // GET: AttendedHours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AttendedHours == null)
            {
                return NotFound();
            }

            var attendedHours = await _context.AttendedHours
                .FirstOrDefaultAsync(m => m.AttendedHoursId == id);
            if (attendedHours == null)
            {
                return NotFound();
            }

            return View(attendedHours);
        }

        // GET: AttendedHours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AttendedHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttendedHoursId,WorkerName,WorkedHour,CheckedIn,CheckedOut,workingStatus,IsAttended")] AttendedHours attendedHours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendedHours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendedHours);
        }

        // GET: AttendedHours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AttendedHours == null)
            {
                return NotFound();
            }

            var attendedHours = await _context.AttendedHours.FindAsync(id);
            if (attendedHours == null)
            {
                return NotFound();
            }
            return View(attendedHours);
        }

        // POST: AttendedHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttendedHoursId,WorkerName,WorkedHour,CheckedIn,CheckedOut,workingStatus,IsAttended")] AttendedHours attendedHours)
        {
            if (id != attendedHours.AttendedHoursId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendedHours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendedHoursExists(attendedHours.AttendedHoursId))
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
            return View(attendedHours);
        }

        // GET: AttendedHours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AttendedHours == null)
            {
                return NotFound();
            }

            var attendedHours = await _context.AttendedHours
                .FirstOrDefaultAsync(m => m.AttendedHoursId == id);
            if (attendedHours == null)
            {
                return NotFound();
            }

            return View(attendedHours);
        }

        // POST: AttendedHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AttendedHours == null)
            {
                return Problem("Entity set 'CarManufactoringContext.AttendedHours'  is null.");
            }
            var attendedHours = await _context.AttendedHours.FindAsync(id);
            if (attendedHours != null)
            {
                _context.AttendedHours.Remove(attendedHours);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendedHoursExists(int id)
        {
          return _context.AttendedHours.Any(e => e.AttendedHoursId == id);
        }
    }
}
