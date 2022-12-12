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
    public class InspectionAndTestsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public InspectionAndTestsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: InspectionAndTests
        public async Task<IActionResult> Index()
        {
              return View(await _context.InspectionAndTest.ToListAsync());
        }

        // GET: InspectionAndTests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InspectionAndTest == null)
            {
                return NotFound();
            }

            var inspectionAndTest = await _context.InspectionAndTest
                .FirstOrDefaultAsync(m => m.InspectionId == id);
            if (inspectionAndTest == null)
            {
                return NotFound();
            }

            return View(inspectionAndTest);
        }

        // GET: InspectionAndTests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InspectionAndTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InspectionId,Date,State,Description")] InspectionAndTest inspectionAndTest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspectionAndTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inspectionAndTest);
        }

        // GET: InspectionAndTests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InspectionAndTest == null)
            {
                return NotFound();
            }

            var inspectionAndTest = await _context.InspectionAndTest.FindAsync(id);
            if (inspectionAndTest == null)
            {
                return NotFound();
            }
            return View(inspectionAndTest);
        }

        // POST: InspectionAndTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InspectionId,Date,State,Description")] InspectionAndTest inspectionAndTest)
        {
            if (id != inspectionAndTest.InspectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspectionAndTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspectionAndTestExists(inspectionAndTest.InspectionId))
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
            return View(inspectionAndTest);
        }

        // GET: InspectionAndTests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InspectionAndTest == null)
            {
                return NotFound();
            }

            var inspectionAndTest = await _context.InspectionAndTest
                .FirstOrDefaultAsync(m => m.InspectionId == id);
            if (inspectionAndTest == null)
            {
                return NotFound();
            }

            return View(inspectionAndTest);
        }

        // POST: InspectionAndTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InspectionAndTest == null)
            {
                return Problem("Entity set 'CarManufactoringContext.inspectionAndTestings'  is null.");
            }
            var inspectionAndTest = await _context.InspectionAndTest.FindAsync(id);
            if (inspectionAndTest != null)
            {
                _context.InspectionAndTest.Remove(inspectionAndTest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspectionAndTestExists(int id)
        {
          return _context.InspectionAndTest.Any(e => e.InspectionId == id);
        }
    }
}
