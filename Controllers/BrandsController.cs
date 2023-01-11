using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.InteropServices;

namespace CarManufactoring.Controllers
{
    [Authorize]
    public class BrandsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public BrandsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Brands
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
              return View(await _context.Brand.ToListAsync());
        }

        // GET: Brands/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Brand == null)
            {
                return NotFound();
            }

            var brand = await _context.Brand
                .FirstOrDefaultAsync(m => m.BrandId == id);
            if (brand == null)
            {
                return View("BrandNotFound");
            }
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(brand);
        }

        // GET: Brands/Create
        [Authorize(Roles = "Colaborator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Create([Bind("BrandId,BrandName")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brand);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Brand created successfully";
                return RedirectToAction(nameof(Details), new {id = brand.BrandId});
            }
            return View(brand);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Brand == null)
            {
                return NotFound();
            }

            var brand = await _context.Brand.FindAsync(id);
            if (brand == null)
            {
                return View("BrandNotFound");
            }
            return View(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrandId,BrandName")] Brand brand)
        {
            if (id != brand.BrandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.BrandId))
                    {
                        return View("BrandNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Brand == null)
            {
                return NotFound();
            }

            var brand = await _context.Brand
                .FirstOrDefaultAsync(m => m.BrandId == id);
            if (brand == null)
            {
                return View("BrandNotFound");
            }
            ViewBag.Error = "Are you sure you want to delete this brand ? ";
            ViewBag.NumberCarBrands = await _context.Car.Where(b => b.BrandId == id).CountAsync();
            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brand == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Brand'  is null.");
            }
            var brand = await _context.Brand.FindAsync(id);
            if (brand != null)
            {
             _context.Brand.Remove(brand);
             await _context.SaveChangesAsync();
            }
            TempData["SuccessMessage"] = "Brand removed successfully.";
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View("BrandDeleted");
        }

        private bool BrandExists(int id)
        {
          return _context.Brand.Any(e => e.BrandId == id);
        }
    }
}
