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
    public class WarehousesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public WarehousesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Warehouses
        public async Task<IActionResult> Index()
        {
            var carManufactoringContext = _context.Warehouse.Include(w => w.Collaborator);
            return View(await carManufactoringContext.ToListAsync());
        }

        // GET: Warehouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Warehouse == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouse
                .Include(w => w.Collaborator)
                .FirstOrDefaultAsync(m => m.WarehouseId == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        // GET: Warehouses/Create
        public IActionResult Create()
        {
            ViewData["CollaboratorID"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email");
            return View();
        }

        // POST: Warehouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WarehouseId,Location,CollaboratorID")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warehouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollaboratorID"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", warehouse.CollaboratorID);
            return View(warehouse);
        }

        // GET: Warehouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Warehouse == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouse.FindAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            ViewData["CollaboratorID"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", warehouse.CollaboratorID);
            return View(warehouse);
        }

        // POST: Warehouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WarehouseId,Location,CollaboratorID")] Warehouse warehouse)
        {
            if (id != warehouse.WarehouseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warehouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarehouseExists(warehouse.WarehouseId))
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
            ViewData["CollaboratorID"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", warehouse.CollaboratorID);
            return View(warehouse);
        }

        // GET: Warehouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Warehouse == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouse
                .Include(w => w.Collaborator)
                .FirstOrDefaultAsync(m => m.WarehouseId == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        // POST: Warehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Warehouse == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Warehouse'  is null.");
            }
            var warehouse = await _context.Warehouse.FindAsync(id);
            if (warehouse != null)
            {
                _context.Warehouse.Remove(warehouse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarehouseExists(int id)
        {
          return _context.Warehouse.Any(e => e.WarehouseId == id);
        }
    }
}
