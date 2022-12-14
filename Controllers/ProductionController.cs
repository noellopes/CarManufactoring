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
    public class ProductionController : Controller
    {
        private readonly CarManufactoringContext _context;

        public ProductionController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Production
        public async Task<IActionResult> Index()
        {
              return View(await _context.Production.ToListAsync());
        }

        // GET: Production/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Production == null)
            {
                return NotFound();
            }

            var production = await _context.Production
                .FirstOrDefaultAsync(m => m.ProductionId == id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        // GET: Production/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Production/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductionId,OrderDate,DeliveryDate")] Production production)
        {
            if (ModelState.IsValid)
            {
                _context.Add(production);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(production);
        }

        // GET: Production/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Production == null)
            {
                return NotFound();
            }

            var production = await _context.Production.FindAsync(id);
            if (production == null)
            {
                return NotFound();
            }
            return View(production);
        }

        // POST: Production/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductionId,OrderDate,DeliveryDate")] Production production)
        {
            if (id != production.ProductionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(production);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionExists(production.ProductionId))
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
            return View(production);
        }

        // GET: Production/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Production == null)
            {
                return NotFound();
            }

            var production = await _context.Production
                .FirstOrDefaultAsync(m => m.ProductionId == id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        // POST: Production/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Production == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Production'  is null.");
            }
            var production = await _context.Production.FindAsync(id);
            if (production != null)
            {
                _context.Production.Remove(production);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionExists(int id)
        {
          return _context.Production.Any(e => e.ProductionId == id);
        }
    }
}
