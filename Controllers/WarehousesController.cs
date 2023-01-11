using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using CarManufactoring.ViewModels.Group2;
using CarManufactoring.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

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
        public async Task<IActionResult> Index(string location = null, int page = 1)
        {
            var warehouses = _context.Warehouse
                .Include(w => w.Collaborator)
                .Where(w => location == null || w.Location.Contains(location)).OrderBy(w => w.Location);

            ViewData["CollaboratorID"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email");

            var pagingInfo = new PagingInfoViewModel(await warehouses.CountAsync(), page);


            var model = new WarehousesIndexViewModel
            {
                WarehousesList = new ListViewModel<Warehouse>
                {
                    List = await warehouses
                        .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                        .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },

                LocationSearch = location
            };

            return View(model);
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
                return View("WarehouseNotFound");
            }

            ViewBag.SuccessMessage = TempData["SuccessMessage"];
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
                TempData["SuccessMessage"] = "Warehouse Added Successfully.";
                return RedirectToAction(nameof(Details), new { id = warehouse.WarehouseId });
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
                return View("WarehouseNotFound");
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
                    TempData["SuccessMessage"] = "Warehouse successfully edited.";
                    return RedirectToAction(nameof(Details), new { id = warehouse.WarehouseId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarehouseExists(warehouse.WarehouseId))
                    {
                        return View("WarehouseNotFound");
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
                return View("WarehouseNotFound");
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
