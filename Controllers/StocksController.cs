using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using CarManufactoring.ViewModels;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.AspNetCore.Authorization;

namespace CarManufactoring.Controllers
{
    [Authorize]
    public class StocksController : Controller
    {
        private readonly CarManufactoringContext _context;

        public StocksController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Stocks
        [AllowAnonymous]
        public async Task<IActionResult> Index(string material = null, string warehouseStock = null, int page = 1)
        {
            var stocks = _context.Stock.Include(s => s.Material).Include(s => s.WarehouseStock)
                .Where(s => material == null || s.Material.Nome.Contains(material))
                .Where(s => warehouseStock == null || s.WarehouseStock.Identification.Contains(warehouseStock))
            .OrderBy(s => s.WarehouseStock);

            var pagingInfo = new PagingInfoViewModel(await stocks.CountAsync(), page);

            var model = new StockIndexViewModel
            {
                StockList = new ListViewModel<Stock>
                {
                    List = await stocks
                        .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                        .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                MaterialSearched = material,
                WarehouseStockSearched = warehouseStock
            };

            return View(model);
        }

        // GET: Stocks/Details/5
        [Authorize(Roles = "Admin,Colaborator,Manager")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stock == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.Material)
                .Include(s => s.WarehouseStock)
                .FirstOrDefaultAsync(m => m.StockId == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Stocks/Create
        [Authorize(Roles = "Admin,Colaborator,Manager")]
        public IActionResult Create()
        {
            ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "Nome");
            ViewData["WarehouseStockId"] = new SelectList(_context.Set<WarehouseStock>(), "WarehouseStockId", "Identification");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Colaborator,Manager")]
        public async Task<IActionResult> Create([Bind("StockId,Quantity,Description,Location,WarehouseStockId,MaterialId")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "Nome", stock.MaterialId);
            ViewData["WarehouseStockId"] = new SelectList(_context.Set<WarehouseStock>(), "WarehouseStockId", "Identification", stock.WarehouseStockId);
            return View(stock);
        }

        // GET: Stocks/Edit/5
        [Authorize(Roles = "Admin,Colaborator,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stock == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "Nome", stock.MaterialId);
            ViewData["WarehouseStockId"] = new SelectList(_context.Set<WarehouseStock>(), "WarehouseStockId", "Identification", stock.WarehouseStockId);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Colaborator,Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("StockId,Quantity,Description,Location,WarehouseStockId,MaterialId")] Stock stock)
        {
            if (id != stock.StockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.StockId))
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
            ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "Nome", stock.MaterialId);
            ViewData["WarehouseStockId"] = new SelectList(_context.Set<WarehouseStock>(), "WarehouseStockId", "Identification", stock.WarehouseStockId);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stock == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.Material)
                .Include(s => s.WarehouseStock)
                .FirstOrDefaultAsync(m => m.StockId == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stock == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Stock'  is null.");
            }
            var stock = await _context.Stock.FindAsync(id);
            if (stock != null)
            {
                _context.Stock.Remove(stock);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(int id)
        {
          return _context.Stock.Any(e => e.StockId == id);
        }
    }
}
