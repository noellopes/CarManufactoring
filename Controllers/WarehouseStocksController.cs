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
            List<Stock> allStockData = new List<Stock>();
            List<Stock> stocks = _context.Stock.ToList();
            for (int i = 0; i < stocks.Count; i++)
            {
                Material material = _context.Material.Select(x => x).Where(x => x.MaterialId == stocks[i].MaterialId).FirstOrDefault();
                WarehouseStock warehouseStock = _context.WarehouseStock.Select(x => x).Where(x => x.WarehouseStockId == stocks[i].WarehouseStockId).FirstOrDefault();
                allStockData.Add(new Stock { 
                    Description = stocks[i].Description, 
                    Location = stocks[i].Location,
                    Material = material,
                    Quantity= stocks[i].Quantity,
                    MaterialId= stocks[i].MaterialId,
                    StockId = stocks[i].StockId,
                    WarehouseStock = warehouseStock,
                    WarehouseStockId = stocks[i].WarehouseStockId
                }) ;
            }

            ViewBag.Stock = allStockData;
              return View();
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

            List<Stock> allStockData = new List<Stock>();
            List<Stock> stocks = _context.Stock.ToList();
            for (int i = 0; i < stocks.Count; i++)
            {
                Material material = _context.Material.Select(x => x).Where(x => x.MaterialId == stocks[i].MaterialId).FirstOrDefault();
                WarehouseStock warehouseStocks = _context.WarehouseStock.Select(x => x).Where(x => x.WarehouseStockId == stocks[i].WarehouseStockId).FirstOrDefault();
                allStockData.Add(new Stock
                {
                    Description = stocks[i].Description,
                    Location = stocks[i].Location,
                    Material = material,
                    Quantity = stocks[i].Quantity,
                    MaterialId = stocks[i].MaterialId,
                    StockId = stocks[i].StockId,
                    WarehouseStock = warehouseStocks,
                    WarehouseStockId = stocks[i].WarehouseStockId
                });
            }

            ViewBag.Stock = allStockData;
            return View();

            //return View(warehouseStock);
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
