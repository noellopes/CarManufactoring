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
    public class StocksController : Controller
    {
        private readonly CarManufactoringContext _context;

        public StocksController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Stocks
        public async Task<IActionResult> Index()
        {
            var carManufactoringContext = _context.Stock.Include(s => s.Collaborator).Include(s => s.Material);
            return View(await carManufactoringContext.ToListAsync());
        }

        // GET: Stocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stock == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.Collaborator)
                .Include(s => s.Material)
                .FirstOrDefaultAsync(m => m.StockId == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email");
            ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "Description");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockId,Quantity,Location,CollaboratorId,MaterialId")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", stock.CollaboratorId);
            ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "Description", stock.MaterialId);
            return View(stock);
        }

        // GET: Stocks/Edit/5
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
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", stock.CollaboratorId);
            ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "Description", stock.MaterialId);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockId,Quantity,Location,CollaboratorId,MaterialId")] Stock stock)
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
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", stock.CollaboratorId);
            ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "Description", stock.MaterialId);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stock == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.Collaborator)
                .Include(s => s.Material)
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
