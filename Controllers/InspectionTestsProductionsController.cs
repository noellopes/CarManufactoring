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
    public class InspectionTestsProductionsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public InspectionTestsProductionsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: InspectionTestsProductions
        public async Task<IActionResult> Index()
        {
            var carManufactoringContext = _context.InspectionTestsProduction.Include(i => i.Production);
            return View(await carManufactoringContext.ToListAsync());
        }

        // GET: InspectionTestsProductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InspectionTestsProduction == null)
            {
                return NotFound();
            }

            var inspectionTestsProduction = await _context.InspectionTestsProduction
                .Include(i => i.Production)
                .FirstOrDefaultAsync(m => m.InspectionTestsProductionId == id);
            if (inspectionTestsProduction == null)
            {
                return NotFound();
            }

            return View(inspectionTestsProduction);
        }

        // GET: InspectionTestsProductions/Create
        public IActionResult Create()
        {
            ViewData["ProductionId"] = new SelectList(_context.Production, "ProductionId", "ProductionId");
            return View();
        }

        // POST: InspectionTestsProductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InspectionTestsProductionId,Lote,InspectionId,ProductionId")] InspectionTestsProduction inspectionTestsProduction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspectionTestsProduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductionId"] = new SelectList(_context.Production, "ProductionId", "ProductionId", inspectionTestsProduction.ProductionId);
            return View(inspectionTestsProduction);
        }

        // GET: InspectionTestsProductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InspectionTestsProduction == null)
            {
                return NotFound();
            }

            var inspectionTestsProduction = await _context.InspectionTestsProduction.FindAsync(id);
            if (inspectionTestsProduction == null)
            {
                return NotFound();
            }
            ViewData["ProductionId"] = new SelectList(_context.Production, "ProductionId", "ProductionId", inspectionTestsProduction.ProductionId);
            return View(inspectionTestsProduction);
        }

        // POST: InspectionTestsProductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InspectionTestsProductionId,Lote,InspectionId,ProductionId")] InspectionTestsProduction inspectionTestsProduction)
        {
            if (id != inspectionTestsProduction.InspectionTestsProductionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspectionTestsProduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspectionTestsProductionExists(inspectionTestsProduction.InspectionTestsProductionId))
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
            ViewData["ProductionId"] = new SelectList(_context.Production, "ProductionId", "ProductionId", inspectionTestsProduction.ProductionId);
            return View(inspectionTestsProduction);
        }

        // GET: InspectionTestsProductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InspectionTestsProduction == null)
            {
                return NotFound();
            }

            var inspectionTestsProduction = await _context.InspectionTestsProduction
                .Include(i => i.Production)
                .FirstOrDefaultAsync(m => m.InspectionTestsProductionId == id);
            if (inspectionTestsProduction == null)
            {
                return NotFound();
            }

            return View(inspectionTestsProduction);
        }

        // POST: InspectionTestsProductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InspectionTestsProduction == null)
            {
                return Problem("Entity set 'CarManufactoringContext.InspectionTestsProduction'  is null.");
            }
            var inspectionTestsProduction = await _context.InspectionTestsProduction.FindAsync(id);
            if (inspectionTestsProduction != null)
            {
                _context.InspectionTestsProduction.Remove(inspectionTestsProduction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspectionTestsProductionExists(int id)
        {
          return _context.InspectionTestsProduction.Any(e => e.InspectionTestsProductionId == id);
        }
    }
}
