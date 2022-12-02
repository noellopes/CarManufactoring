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
    public class InspectionAndTestingController : Controller
    {
        private readonly CarManufactoringContext _context;

        public InspectionAndTestingController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: InspectionAndTesting
        public async Task<IActionResult> Index()
        {
              return View(await _context.inspectionAndTestings.ToListAsync());
        }

        // GET: InspectionAndTesting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.inspectionAndTestings == null)
            {
                return NotFound();
            }

            var inspectionAndTesting = await _context.inspectionAndTestings
                .FirstOrDefaultAsync(m => m.InspectionId == id);
            if (inspectionAndTesting == null)
            {
                return NotFound();
            }

            return View(inspectionAndTesting);
        }

        // GET: InspectionAndTesting/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InspectionAndTesting/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InspectionId,Date,State,Description")] InspectionAndTesting inspectionAndTesting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspectionAndTesting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inspectionAndTesting);
        }

        // GET: InspectionAndTesting/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.inspectionAndTestings == null)
            {
                return NotFound();
            }

            var inspectionAndTesting = await _context.inspectionAndTestings.FindAsync(id);
            if (inspectionAndTesting == null)
            {
                return NotFound();
            }
            return View(inspectionAndTesting);
        }

        // POST: InspectionAndTesting/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InspectionId,Date,State,Description")] InspectionAndTesting inspectionAndTesting)
        {
            if (id != inspectionAndTesting.InspectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspectionAndTesting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspectionAndTestingExists(inspectionAndTesting.InspectionId))
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
            return View(inspectionAndTesting);
        }

        // GET: InspectionAndTesting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.inspectionAndTestings == null)
            {
                return NotFound();
            }

            var inspectionAndTesting = await _context.inspectionAndTestings
                .FirstOrDefaultAsync(m => m.InspectionId == id);
            if (inspectionAndTesting == null)
            {
                return NotFound();
            }

            return View(inspectionAndTesting);
        }

        // POST: InspectionAndTesting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.inspectionAndTestings == null)
            {
                return Problem("Entity set 'CarManufactoringContext.inspectionAndTestings'  is null.");
            }
            var inspectionAndTesting = await _context.inspectionAndTestings.FindAsync(id);
            if (inspectionAndTesting != null)
            {
                _context.inspectionAndTestings.Remove(inspectionAndTesting);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspectionAndTestingExists(int id)
        {
          return _context.inspectionAndTestings.Any(e => e.InspectionId == id);
        }
    }
}
