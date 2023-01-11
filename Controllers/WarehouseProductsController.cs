using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using Microsoft.CodeAnalysis;
using CarManufactoring.ViewModels.Group2;
using CarManufactoring.ViewModels;

namespace CarManufactoring.Controllers
{
    public class WarehouseProductsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public WarehouseProductsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: WarehouseProducts
        public async Task<IActionResult> Index(int warehouse, int product, int quantity, int stockmax, int page = 1)
        {

            var warehouseproducts = _context.WarehouseProduct
                .Include(w => w.CarParts)
                .Include(w => w.Warehouses)
                .Where(w => quantity == 0 || w.Quantity.Equals(quantity))
                .Where(w => stockmax == 0 || w.StockMax.Equals(stockmax));

            

            ViewData["ProductId"] = new SelectList(_context.CarParts, "ProductId", "Name");
            ViewData["WarehouseId"] = new SelectList(_context.Warehouse, "WarehouseId", "Location");

            Warehouse SelectedWarehouse = null;
            try
            {
                SelectedWarehouse = _context.Warehouse.First(g => g.WarehouseId == warehouse);

            }
            catch (Exception)
            {

            }
            if (warehouse != 0 && SelectedWarehouse != null)
            {
                warehouseproducts = warehouseproducts.Where(m => m.WarehouseId == warehouse);
            }

            CarParts SelectedProduct = null;
            try
            {
                SelectedProduct = _context.CarParts.First(g => g.ProductId == product);

            }
            catch (Exception)
            {

            }
            if (product != 0 && SelectedProduct != null)
            {
                warehouseproducts = warehouseproducts.Where(m => m.ProductId == product);
            }

            var pagingInfo = new PagingInfoViewModel(await warehouseproducts.CountAsync(), page);


            var model = new WarehouseProductsIndexViewModel
            {
                WarehouseProductsList = new ListViewModel<WarehouseProduct>
                {
                    List = await warehouseproducts
                        .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                        .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },

                WarehouseSearch = warehouse,
                ProductSearch = product,

            };

            return View(model);
        }


        // GET: WarehouseProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WarehouseProduct == null)
            {
                return NotFound();
            }

            var warehouseProduct = await _context.WarehouseProduct
                .Include(w => w.CarParts)
                .Include(w => w.Warehouses)
                .FirstOrDefaultAsync(m => m.WarehouseId == id);
            if (warehouseProduct == null)
            {
                return View("WarehouseProductNotFound");
            }

            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(warehouseProduct);
        }

        // GET: WarehouseProducts/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.CarParts, "ProductId", "Name");
            ViewData["WarehouseId"] = new SelectList(_context.Warehouse, "WarehouseId", "Location");
            return View();
        }

        // POST: WarehouseProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WarehouseId,ProductId,Quantity,StockMax")] WarehouseProduct warehouseProduct)
        {
            if (warehouseProduct.Quantity > warehouseProduct.StockMax)
            {
                ModelState.AddModelError("Quantity", "Quantity cant be higher than StockMax");

            }else if (ModelState.IsValid)
            {
                _context.Add(warehouseProduct);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "WarehouseProduct Added Successfully.";
                return RedirectToAction(nameof(Details), new { id = warehouseProduct.WarehouseId });
            }
            ViewData["ProductId"] = new SelectList(_context.CarParts, "ProductId", "Name", warehouseProduct.ProductId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouse, "WarehouseId", "Location", warehouseProduct.WarehouseId);
            return View(warehouseProduct);
        }

        // GET: WarehouseProducts/Edit/5
        public async Task<IActionResult> Edit(int? id, int? id1)
        {
            if (id == null || _context.WarehouseProduct == null)
            {
                return NotFound();
            }

            var warehouseProduct = await _context.WarehouseProduct.FindAsync(id,id1);
            if (warehouseProduct == null)
            {
                return View("WarehouseProductNotFound");
            }
            ViewData["ProductId"] = new SelectList(_context.CarParts, "ProductId", "Name", warehouseProduct.ProductId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouse, "WarehouseId", "Collaborator", warehouseProduct.WarehouseId);
            return View(warehouseProduct);
        }

        // POST: WarehouseProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, int? id1, [Bind("WarehouseId,ProductId,Quantity,StockMax")] WarehouseProduct warehouseProduct)
        {
            if (id != warehouseProduct.WarehouseId && id1 != warehouseProduct.ProductId)
            {
                return View("WarehouseProductNotFound");
            }

            if (warehouseProduct.Quantity > warehouseProduct.StockMax)
            {
                ModelState.AddModelError("Quantity", "StockMax cant be higher than Quantity");

            }
            else if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warehouseProduct);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "WarehouseProduct successfully edited.";
                    return RedirectToAction(nameof(Details), new { id = warehouseProduct.WarehouseId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarehouseProductExists(warehouseProduct.WarehouseId, warehouseProduct.ProductId))
                    {
                        return View("WarehouseProductNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.CarParts, "ProductId", "Name", warehouseProduct.ProductId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouse, "WarehouseId", "Collaborator", warehouseProduct.WarehouseId);
            return View(warehouseProduct);
        }

        // GET: WarehouseProducts/Delete/5
        public async Task<IActionResult> Delete(int? id, int? id1)
        {
            if (id == null || id1 == null || _context.WarehouseProduct == null)
            {
                return NotFound();
            }

            var warehouseProduct = await _context.WarehouseProduct
                .Include(w => w.CarParts)
                .Include(w => w.Warehouses)
                .FirstOrDefaultAsync(m => m.WarehouseId == id && m.ProductId == id1);
            if (warehouseProduct == null)
            {
                return View("WarehouseProductNotFound");
            }

            return View(warehouseProduct);
        }

        // POST: WarehouseProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id, int? id1)
        {
            if (_context.WarehouseProduct == null)
            {
                return Problem("Entity set 'CarManufactoringContext.WarehouseProduct'  is null.");
            }
            var warehouseProduct = await _context.WarehouseProduct.Where(m => m.WarehouseId == id || m.ProductId == id1).ToListAsync();
            if (warehouseProduct != null)
            {
                _context.WarehouseProduct.Remove(warehouseProduct[0]);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarehouseProductExists(int id, int id1)
        {
          return _context.WarehouseProduct.Any(e => e.ProductId == id1 && e.WarehouseId == id);
        }
    }
}
