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
    public class ShiftSchedulesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public ShiftSchedulesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: ShiftSchedules
        public async Task<IActionResult> Index()
        {
              return View(await _context.ShiftSchedule.ToListAsync());
        }

        // GET: ShiftSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShiftSchedule == null)
            {
                return NotFound();
            }

            var shiftSchedule = await _context.ShiftSchedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shiftSchedule == null)
            {
                return NotFound();
            }

            return View(shiftSchedule);
        }

        // GET: ShiftSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShiftSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,Duration,EmployeeName,EmployeeSurname")] ShiftSchedule shiftSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shiftSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shiftSchedule);
        }

        // GET: ShiftSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShiftSchedule == null)
            {
                return NotFound();
            }

            var shiftSchedule = await _context.ShiftSchedule.FindAsync(id);
            if (shiftSchedule == null)
            {
                return NotFound();
            }
            return View(shiftSchedule);
        }

        // POST: ShiftSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,Duration,EmployeeName,EmployeeSurname")] ShiftSchedule shiftSchedule)
        {
            if (id != shiftSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shiftSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftScheduleExists(shiftSchedule.Id))
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
            return View(shiftSchedule);
        }

        // GET: ShiftSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShiftSchedule == null)
            {
                return NotFound();
            }

            var shiftSchedule = await _context.ShiftSchedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shiftSchedule == null)
            {
                return NotFound();
            }

            return View(shiftSchedule);
        }

        // POST: ShiftSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShiftSchedule == null)
            {
                return Problem("Entity set 'CarManufactoringContext.ShiftSchedule'  is null.");
            }
            var shiftSchedule = await _context.ShiftSchedule.FindAsync(id);
            if (shiftSchedule != null)
            {
                _context.ShiftSchedule.Remove(shiftSchedule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShiftScheduleExists(int id)
        {
          return _context.ShiftSchedule.Any(e => e.Id == id);
        }
    }
}
