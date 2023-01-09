﻿using System;
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
    public class SupplierPartsCarPartsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public SupplierPartsCarPartsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: SupplierPartsCarParts
        public async Task<IActionResult> Index(int supplierid = 0, int page = 1)
        {

            var supplierpartscarparts = _context.SupplierPartsCarParts
                .Include(s => s.CarParts)
                .Include(s => s.SupplierParts)
                .Where(s => supplierid == 0 || s.SupplierPartsId.Equals(supplierid))
                .OrderBy(s => s.ProductId);

            var pagingInfo = new PagingInfoViewModel(await supplierpartscarparts.CountAsync(), page);

            try
            {
                var model = new SupplierPartsCarPartsIndexViewModel
                {
                    SupplierPartsCarPartsList = new ListViewModel<SupplierPartsCarParts>
                    {
                        List = await supplierpartscarparts
                        .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                        .Take(pagingInfo.PageSize).ToListAsync(),
                        PagingInfo = pagingInfo
                    },

                    SupplierId = supplierid

                };

                return View(model);

            }
            catch (Exception ex)
            {
                return await Index(0, page);
            }
        }


        // GET: SupplierPartsCarParts/Delete/5
        public async Task<IActionResult> Delete(int? SupplierPartsId, int? ProductId)
        {
            if (SupplierPartsId == null || ProductId == null || _context.SupplierPartsCarParts == null)
            {
                return NotFound();
            }

            var supplierPartsCarParts = await _context.SupplierPartsCarParts
                .Include(m => m.SupplierParts)
                .Include(m => m.CarParts)
                .FirstOrDefaultAsync(m => m.ProductId == ProductId && m.SupplierPartsId == SupplierPartsId);

            if (supplierPartsCarParts == null)
            {
                return NotFound();
            }

            return View(supplierPartsCarParts);
        }

        // POST: SupplierPartsCarParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int SupplierPartsId, int ProductId)
        {
            if (_context.SupplierPartsCarParts == null)
            {
                return Problem("Entity set 'CarManufactoringContext.ModelParts'  is null.");
            }
            var supplierPartsCarParts = await _context.SupplierPartsCarParts.Where(m => m.SupplierPartsId == SupplierPartsId && m.ProductId == ProductId).ToListAsync();
            if (supplierPartsCarParts != null)
            {
                _context.SupplierPartsCarParts.Remove(supplierPartsCarParts[0]);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { SupplierPartsId = SupplierPartsId, page = 1 });
        }




        private bool ModelPartsExists(int SupplierPartsId, int ProductId)
        {
            return _context.SupplierPartsCarParts.Any(e => e.ProductId == ProductId && e.SupplierPartsId == SupplierPartsId);
        }
    }
}
