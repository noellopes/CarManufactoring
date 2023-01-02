﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using CarManufactoring.ViewModels;

using CarManufactoring.ViewModels.Group2;

namespace CarManufactoring.Controllers
{
    public class SupplierPartsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public SupplierPartsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: SupplierParts
        public async Task<IActionResult> Index(string name = null ,string country= null, string email = null ,int page = 1)
        {
            var supplierparts = _context.SupplierParts
              .Where(b => name == null || b.Name.Contains(name))
              .Where(b => country == null || b.Country.Contains(country))
              .Where(b => email == null || b.Email.Contains(email))
              .OrderBy(b => b.Name);

            var pagingInfo = new PagingInfoViewModel(await supplierparts.CountAsync(), page);

            try
            {
                var model = new SupplierPartsIndexViewModel
            {
                SupplierPartsList = new ListViewModel<SupplierParts>
                {
                    List = await supplierparts
                        .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                        .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },

                NameSearch = name,
                CountrySearch = country,
                EmailSearch = email

            };

                return View(model);

            }
            catch (Exception ex)
            {
                return await Index(null, null, null ,page);
            }

        }

        // GET: SupplierParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SupplierParts == null)
            {
                return NotFound();
            }

            var supplierParts = await _context.SupplierParts
                .FirstOrDefaultAsync(m => m.SupplierPartsId == id);
            if (supplierParts == null)
            {
                return NotFound();
            }
            ViewBag.SuccessMessageSuppliersParts = TempData["SuccessMessageSuppliersParts"];

            return View(supplierParts);
        }

        // GET: SupplierParts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupplierParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierPartsId,Logo,Name,Email,Contact,ZipCode,Address,Country")] SupplierParts supplierParts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplierParts);
                await _context.SaveChangesAsync();
                TempData["SuccessMessageSuppliersParts"] = "Created Successfully!";
                return RedirectToAction(nameof(Details),new { id = supplierParts.SupplierPartsId });
            }
            return View(supplierParts);
        }

        // GET: SupplierParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SupplierParts == null)
            {
                return NotFound();
            }

            var supplierParts = await _context.SupplierParts.FindAsync(id);
            if (supplierParts == null)
            {
                return NotFound();
            }
            return View(supplierParts);
        }

        // POST: SupplierParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierPartsId,Logo,Name,Email,Contact,ZipCode,Address,Country")] SupplierParts supplierParts)
        {
            if (id != supplierParts.SupplierPartsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierParts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierPartsExists(supplierParts.SupplierPartsId))
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
            return View(supplierParts);
        }

        // GET: SupplierParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SupplierParts == null)
            {
                return NotFound();
            }

            var supplierParts = await _context.SupplierParts
                .FirstOrDefaultAsync(m => m.SupplierPartsId == id);
            if (supplierParts == null)
            {
                return NotFound();
            }

            return View(supplierParts);
        }

        // POST: SupplierParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SupplierParts == null)
            {
                return Problem("Entity set 'CarManufactoringContext.SupplierParts'  is null.");
            }
            var supplierParts = await _context.SupplierParts.FindAsync(id);
            if (supplierParts != null)
            {
                _context.SupplierParts.Remove(supplierParts);
            }
            
            await _context.SaveChangesAsync();
            return View("SupplierPartDeleted");
        }

        private bool SupplierPartsExists(int id)
        {
          return _context.SupplierParts.Any(e => e.SupplierPartsId == id);
        }
    }
}
