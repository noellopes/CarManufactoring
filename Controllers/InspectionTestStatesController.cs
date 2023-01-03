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
    public class InspectionTestStatesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public InspectionTestStatesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: InspectionTestStates
        public async Task<IActionResult> Index()
        {
              return View(await _context.InspectionTestState.ToListAsync());
        }

        // GET: InspectionTestStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InspectionTestState == null)
            {
                return NotFound();
            }

            var inspectionTestState = await _context.InspectionTestState
                .FirstOrDefaultAsync(m => m.InspectionTestStateId == id);
            if (inspectionTestState == null)
            {
                return NotFound();
            }

            return View(inspectionTestState);
        }

        // GET: InspectionTestStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InspectionTestStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InspectionTestStateId,State")] InspectionTestState inspectionTestState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspectionTestState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inspectionTestState);
        }

        // GET: InspectionTestStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InspectionTestState == null)
            {
                return NotFound();
            }

            var inspectionTestState = await _context.InspectionTestState.FindAsync(id);
            if (inspectionTestState == null)
            {
                return NotFound();
            }
            return View(inspectionTestState);
        }

        // POST: InspectionTestStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InspectionTestStateId,State")] InspectionTestState inspectionTestState)
        {
            if (id != inspectionTestState.InspectionTestStateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspectionTestState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspectionTestStateExists(inspectionTestState.InspectionTestStateId))
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
            return View(inspectionTestState);
        }

        // GET: InspectionTestStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InspectionTestState == null)
            {
                return NotFound();
            }

            var inspectionTestState = await _context.InspectionTestState
                .FirstOrDefaultAsync(m => m.InspectionTestStateId == id);
            if (inspectionTestState == null)
            {
                return NotFound();
            }

            return View(inspectionTestState);
        }

        // POST: InspectionTestStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InspectionTestState == null)
            {
                return Problem("Entity set 'CarManufactoringContext.InspectionTestState'  is null.");
            }
            var inspectionTestState = await _context.InspectionTestState.FindAsync(id);
            if (inspectionTestState != null)
            {
                _context.InspectionTestState.Remove(inspectionTestState);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspectionTestStateExists(int id)
        {
          return _context.InspectionTestState.Any(e => e.InspectionTestStateId == id);
        }
    }
}
