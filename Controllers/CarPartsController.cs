﻿using System;
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
    public class CarPartsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public CarPartsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: CarParts
        public async Task<IActionResult> Index()
        {
              return View(await _context.CarParts.ToListAsync());
        }

        // GET: CarParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarParts == null)
            {
                return NotFound();
            }

            var carParts = await _context.CarParts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (carParts == null)
            {
                return NotFound();
            }

            return View(carParts);
        }

        // GET: CarParts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarType,CarModel,CarBrand,ProductId,Reference,Name,PointOfPurchase,SafetyStock,LevelService,StockState")] CarParts carParts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carParts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carParts);
        }

        // GET: CarParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarParts == null)
            {
                return NotFound();
            }

            var carParts = await _context.CarParts.FindAsync(id);
            if (carParts == null)
            {
                return NotFound();
            }
            return View(carParts);
        }

        // POST: CarParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarType,CarModel,CarBrand,ProductId,Reference,Name,PointOfPurchase,SafetyStock,LevelService,StockState")] CarParts carParts)
        {
            if (id != carParts.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carParts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarPartsExists(carParts.ProductId))
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
            return View(carParts);
        }

        // GET: CarParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarParts == null)
            {
                return NotFound();
            }

            var carParts = await _context.CarParts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (carParts == null)
            {
                return NotFound();
            }

            return View(carParts);
        }

        // POST: CarParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarParts == null)
            {
                return Problem("Entity set 'CarManufactoringContext.CarParts'  is null.");
            }
            var carParts = await _context.CarParts.FindAsync(id);
            if (carParts != null)
            {
                _context.CarParts.Remove(carParts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarPartsExists(int id)
        {
          return _context.CarParts.Any(e => e.ProductId == id);
        }
    }
}