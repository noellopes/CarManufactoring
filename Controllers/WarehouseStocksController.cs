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
    public class WarehouseStocksController : Controller
    {
        private readonly CarManufactoringContext _context;

        public WarehouseStocksController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: WarehouseStocks
        public async Task<IActionResult> Index()
        {
              return View(await _context.WarehouseStock.ToListAsync());
        }

        // GET: WarehouseStocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WarehouseStock == null)
            {
                return NotFound();
            }

            var warehouseStock = await _context.WarehouseStock
                .FirstOrDefaultAsync(m => m.WarehouseStockId == id);
            if (warehouseStock == null)
            {
                return NotFound();
            }

            return View(warehouseStock);
        }

        // GET: WarehouseStocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WarehouseStocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WarehouseStockId,Identification")] WarehouseStock warehouseStock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warehouseStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(warehouseStock);
        }

        // GET: WarehouseStocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WarehouseStock == null)
            {
                return NotFound();
            }

            var warehouseStock = await _context.WarehouseStock.FindAsync(id);
            if (warehouseStock == null)
            {
                return NotFound();
            }
            return View(warehouseStock);
        }

        // POST: WarehouseStocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WarehouseStockId,Identification")] WarehouseStock warehouseStock)
        {
            if (id != warehouseStock.WarehouseStockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warehouseStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarehouseStockExists(warehouseStock.WarehouseStockId))
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
            return View(warehouseStock);
        }

        // GET: WarehouseStocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WarehouseStock == null)
            {
                return NotFound();
            }

            var warehouseStock = await _context.WarehouseStock
                .FirstOrDefaultAsync(m => m.WarehouseStockId == id);
            if (warehouseStock == null)
            {
                return NotFound();
            }

            return View(warehouseStock);
        }

        // POST: WarehouseStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WarehouseStock == null)
            {
                return Problem("Entity set 'CarManufactoringContext.WarehouseStock'  is null.");
            }
            var warehouseStock = await _context.WarehouseStock.FindAsync(id);
            if (warehouseStock != null)
            {
                _context.WarehouseStock.Remove(warehouseStock);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarehouseStockExists(int id)
        {
          return _context.WarehouseStock.Any(e => e.WarehouseStockId == id);
        }
    }
}
