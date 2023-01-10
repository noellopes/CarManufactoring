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
using CarManufactoring.ViewModels.Group4;
using System.Data;
using Microsoft.AspNetCore.Authorization;
namespace CarManufactoring.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly CarManufactoringContext _context;

        public SuppliersController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index(string supplierName = null, string supplierEmail = null, int page = 1)
        {
            
            var supplier = _context.Supplier
              .Where(b => supplierName == null || b.SupplierName.Contains(supplierEmail))
              .Where(b => supplierEmail == null || b.SupplierEmail.Contains(supplierEmail))
              .OrderBy(b => b.SupplierName);

            var pagingInfo = new PagingInfoViewModel(await supplier.CountAsync(), page);

            try
            {

                var model = new SupplierIndexViewModel
                {
                    SupplierList = new ListViewModel<Supplier>
                    {
                        List = await supplier
                        .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                        .Take(pagingInfo.PageSize).ToListAsync(),
                        PagingInfo = pagingInfo
                    },

                    SupplierNameSearch = supplierEmail,
                    SupplierEmailSearch = supplierEmail

                };

                return View(model);

            }
            catch (Exception ex)
            {
                return await Index(null, null, page);
            }

        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Supplier == null)
            {
                return NotFound();
            }

            var Supplier = await _context.Supplier
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (Supplier == null)
            {
                return NotFound();
            }
            ViewBag.SuccessMessageSuppliers = TempData["SuccessMessageSuppliers"];

            return View(Supplier);
        }

        // GET: Suppliers/Create
        //[Authorize(Roles = "Admin, Supplier Eginner")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,SupplierName,SupplierEmail,SupplierContact,SupplierZipCode,SupplierAddress")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        //[Authorize(Roles = "Admin, Suppliers Eginner")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Supplier == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, Supplier Eginner")]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierId,SupplierName,SupplierEmail,SupplierContact,SupplierZipCode,SupplierAddress")] Supplier supplier)
        {
            if (id != supplier.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.SupplierId))
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
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        //[Authorize(Roles = "Admin, Supplier Eginner")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Supplier == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, Supplier Eginner")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Supplier == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Supplier'  is null.");
            }
            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier != null)
            {
                _context.Supplier.Remove(supplier);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierExists(int id)
        {
          return _context.Supplier.Any(e => e.SupplierId == id);
        }
    }
}
