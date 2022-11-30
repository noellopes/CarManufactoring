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
    public class CarConfigsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public CarConfigsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: CarConfigs
        public async Task<IActionResult> Index()
        {
              return View(await _context.CarConfig.ToListAsync());
        }

        // GET: CarConfigs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarConfig == null)
            {
                return NotFound();
            }

            var carConfig = await _context.CarConfig
                .FirstOrDefaultAsync(m => m.CarConfigId == id);
            if (carConfig == null)
            {
                return NotFound();
            }

            return View(carConfig);
        }

        // GET: CarConfigs/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Set<Car>(), "CarId", "CarModel");
            return View();
        }

        // POST: CarConfigs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarConfigId,ConfigName,NumExtras,AddedPrice,CarId")] CarConfig carConfig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carConfig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Set<Car>(), "CarId", "CarModel");
            return View(carConfig);
        }

        // GET: CarConfigs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarConfig == null)
            {
                return NotFound();
            }

            var carConfig = await _context.CarConfig.FindAsync(id);
            if (carConfig == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Set<Car>(), "CarId", "CarModel");
            return View(carConfig);
        }

        // POST: CarConfigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarConfigId,ConfigName,NumExtras,AddedPrice, CarId")] CarConfig carConfig)
        {
            if (id != carConfig.CarConfigId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carConfig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarConfigExists(carConfig.CarConfigId))
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
            ViewData["CarId"] = new SelectList(_context.Set<Car>(), "CarId", "CarModel");
            return View(carConfig);
        }

        // GET: CarConfigs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarConfig == null)
            {
                return NotFound();
            }

            var carConfig = await _context.CarConfig
                .FirstOrDefaultAsync(m => m.CarConfigId == id);
            if (carConfig == null)
            {
                return NotFound();
            }

            return View(carConfig);
        }

        // POST: CarConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarConfig == null)
            {
                return Problem("Entity set 'CarManufactoringContext.CarConfig'  is null.");
            }
            var carConfig = await _context.CarConfig.FindAsync(id);
            if (carConfig != null)
            {
                _context.CarConfig.Remove(carConfig);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarConfigExists(int id)
        {
          return _context.CarConfig.Any(e => e.CarConfigId == id);
        }
    }
}