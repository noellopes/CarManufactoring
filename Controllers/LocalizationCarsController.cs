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
    public class LocalizationCarsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public LocalizationCarsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: LocalizationCars
        public async Task<IActionResult> Index()
        {
              return View(await _context.LocalizationCar.ToListAsync());
        }

        // GET: LocalizationCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LocalizationCar == null)
            {
                return NotFound();
            }

            var localizationCar = await _context.LocalizationCar
                .FirstOrDefaultAsync(m => m.LocalizationCarId == id);
            if (localizationCar == null)
            {
                return NotFound();
            }

            return View(localizationCar);
        }

        // GET: LocalizationCars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocalizationCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocalizationCarId,Line,Row")] LocalizationCar localizationCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localizationCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localizationCar);
        }

        // GET: LocalizationCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LocalizationCar == null)
            {
                return NotFound();
            }

            var localizationCar = await _context.LocalizationCar.FindAsync(id);
            if (localizationCar == null)
            {
                return NotFound();
            }
            return View(localizationCar);
        }

        // POST: LocalizationCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocalizationCarId,Line,Row")] LocalizationCar localizationCar)
        {
            if (id != localizationCar.LocalizationCarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localizationCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalizationCarExists(localizationCar.LocalizationCarId))
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
            return View(localizationCar);
        }

        // GET: LocalizationCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LocalizationCar == null)
            {
                return NotFound();
            }

            var localizationCar = await _context.LocalizationCar
                .FirstOrDefaultAsync(m => m.LocalizationCarId == id);
            if (localizationCar == null)
            {
                return NotFound();
            }

            return View(localizationCar);
        }

        // POST: LocalizationCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LocalizationCar == null)
            {
                return Problem("Entity set 'CarManufactoringContext.LocalizationCar'  is null.");
            }
            var localizationCar = await _context.LocalizationCar.FindAsync(id);
            if (localizationCar != null)
            {
                _context.LocalizationCar.Remove(localizationCar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalizationCarExists(int id)
        {
          return _context.LocalizationCar.Any(e => e.LocalizationCarId == id);
        }
    }
}
