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
    public class StockFinalProductsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public StockFinalProductsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: StockFinalProducts
        public async Task<IActionResult> Index()
        {
            var carManufactoringContext = _context.StockFinalProduct.Include(s => s.Production);
            return View(await carManufactoringContext.ToListAsync());
        }

        // GET: StockFinalProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StockFinalProduct == null)
            {
                return NotFound();
            }

            var stockFinalProduct = await _context.StockFinalProduct
                .Include(s => s.Production)
                .FirstOrDefaultAsync(m => m.LocalizationCarId == id);
            if (stockFinalProduct == null)
            {
                return NotFound();
            }

            return View(stockFinalProduct);
        }

        // GET: StockFinalProducts/Create
        public IActionResult Create()
        {
            ViewData["ProductionId"] = new SelectList(_context.Production, "ProductionId", "ProductionId");
            return View();
        }

        // POST: StockFinalProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocalizationCarId,ChassiNumber,ProductionId")] StockFinalProduct stockFinalProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockFinalProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductionId"] = new SelectList(_context.Production, "ProductionId", "ProductionId", stockFinalProduct.ProductionId);
            return View(stockFinalProduct);
        }

        // GET: StockFinalProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StockFinalProduct == null)
            {
                return NotFound();
            }

            var stockFinalProduct = await _context.StockFinalProduct.FindAsync(id);
            if (stockFinalProduct == null)
            {
                return NotFound();
            }
            ViewData["ProductionId"] = new SelectList(_context.Production, "ProductionId", "ProductionId", stockFinalProduct.ProductionId);
            return View(stockFinalProduct);
        }

        // POST: StockFinalProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocalizationCarId,ChassiNumber,ProductionId")] StockFinalProduct stockFinalProduct)
        {
            if (id != stockFinalProduct.LocalizationCarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockFinalProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockFinalProductExists(stockFinalProduct.LocalizationCarId))
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
            ViewData["ProductionId"] = new SelectList(_context.Production, "ProductionId", "ProductionId", stockFinalProduct.ProductionId);
            return View(stockFinalProduct);
        }

        // GET: StockFinalProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StockFinalProduct == null)
            {
                return NotFound();
            }

            var stockFinalProduct = await _context.StockFinalProduct
                .Include(s => s.Production)
                .FirstOrDefaultAsync(m => m.LocalizationCarId == id);
            if (stockFinalProduct == null)
            {
                return NotFound();
            }

            return View(stockFinalProduct);
        }

        // POST: StockFinalProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StockFinalProduct == null)
            {
                return Problem("Entity set 'CarManufactoringContext.StockFinalProduct'  is null.");
            }
            var stockFinalProduct = await _context.StockFinalProduct.FindAsync(id);
            if (stockFinalProduct != null)
            {
                _context.StockFinalProduct.Remove(stockFinalProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockFinalProductExists(int id)
        {
          return _context.StockFinalProduct.Any(e => e.LocalizationCarId == id);
        }
    }
}
