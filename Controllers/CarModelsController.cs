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
    public class CarModelsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public CarModelsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: CarModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.CarModels.ToListAsync());
        }

        // GET: CarModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarModels == null)
            {
                return NotFound();
            }

            var carModels = await _context.CarModels
                .FirstOrDefaultAsync(m => m.CarModelId == id);
            if (carModels == null)
            {
                return NotFound();
            }

            return View(carModels);
        }

        // GET: CarModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarModelId,CarName,ConfigName")] CarModels carModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carModels);
        }

        // GET: CarModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarModels == null)
            {
                return NotFound();
            }

            var carModels = await _context.CarModels.FindAsync(id);
            if (carModels == null)
            {
                return NotFound();
            }
            return View(carModels);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarModelId,CarName,ConfigName")] CarModels carModels)
        {
            if (id != carModels.CarModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarModelsExists(carModels.CarModelId))
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
            return View(carModels);
        }

        // GET: CarModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarModels == null)
            {
                return NotFound();
            }

            var carModels = await _context.CarModels
                .FirstOrDefaultAsync(m => m.CarModelId == id);
            if (carModels == null)
            {
                return NotFound();
            }

            return View(carModels);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarModels == null)
            {
                return Problem("Entity set 'CarManufactoringContext.CarModels'  is null.");
            }
            var carModels = await _context.CarModels.FindAsync(id);
            if (carModels != null)
            {
                _context.CarModels.Remove(carModels);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarModelsExists(int id)
        {
          return _context.CarModels.Any(e => e.CarModelId == id);
        }
    }
}
