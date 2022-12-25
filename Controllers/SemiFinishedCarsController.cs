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
    public class SemiFinishedCarsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public SemiFinishedCarsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: SemiFinishedCars
        public async Task<IActionResult> Index()
        {
            var carManufactoringContext = _context.SemiFinishedCar.Include(s => s.Car.Brand).Include(s => s.SemiFinished);
            return View(await carManufactoringContext.ToListAsync());
        }

        // GET: SemiFinishedCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SemiFinishedCar == null)
            {
                return NotFound();
            }

            var semiFinishedCar = await _context.SemiFinishedCar
                .Include(s => s.Car.Brand)
                .Include(s => s.SemiFinished)
                .FirstOrDefaultAsync(m => m.SemiFinishedId == id);
            if (semiFinishedCar == null)
            {
                return View("SemiFinishedCarNotFound");
            }
            ViewBag.SuccessMessage = TempData["SemiFinishedCar_SuccessMessage"];
            return View(semiFinishedCar);
        }

        // GET: SemiFinishedCars/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarId");
            ViewData["SemiFinishedId"] = new SelectList(_context.SemiFinished, "SemiFinishedId", "Reference");

            return View();
        }

        // POST: SemiFinishedCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SemiFinishedCarId,SemiFinishedId,CarId")] SemiFinishedCar semiFinishedCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(semiFinishedCar);
                await _context.SaveChangesAsync();
                TempData["SemiFinishedCar_SuccessMessage"] = "Relation created successfully.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarId", semiFinishedCar.CarId);
            ViewData["SemiFinishedId"] = new SelectList(_context.SemiFinished, "SemiFinishedId", "Reference", semiFinishedCar.SemiFinishedId);
            return View(semiFinishedCar);
        }

        // GET: SemiFinishedCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SemiFinishedCar == null)
            {
                return NotFound();
            }

            var semiFinishedCar = await _context.SemiFinishedCar.FindAsync(id);
            if (semiFinishedCar == null)
            {
                return NotFound("SemiFinishedCarNotFound");
            }
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarId", semiFinishedCar.CarId);
            ViewData["SemiFinishedId"] = new SelectList(_context.SemiFinished, "SemiFinishedId", "Reference", semiFinishedCar.SemiFinishedId);
            return View(semiFinishedCar);
        }

        // POST: SemiFinishedCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("SemiFinishedCarId,SemiFinishedId,CarId")] SemiFinishedCar semiFinishedCar)
        {
            if (id != semiFinishedCar.SemiFinishedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(semiFinishedCar);
                    await _context.SaveChangesAsync();
                    TempData["SemiFinishedCar_SuccessMessage"] = "Relation Successfully Edited";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SemiFinishedCarExists(semiFinishedCar.SemiFinishedId))
                    {
                        return View("SemiFinishedCarNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarId", semiFinishedCar.CarId);
            ViewData["SemiFinishedId"] = new SelectList(_context.SemiFinished, "SemiFinishedId", "Reference", semiFinishedCar.SemiFinishedId);
            return View(semiFinishedCar);
        }

        // GET: SemiFinishedCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SemiFinishedCar == null)
            {
                return NotFound();
            }

            var semiFinishedCar = await _context.SemiFinishedCar
                .Include(s => s.Car.Brand)
                .Include(s => s.SemiFinished)
                .FirstOrDefaultAsync(m => m.SemiFinishedId == id);
            if (semiFinishedCar == null)
            {
                return View("SemiFinishedCarNotFound");
            }

            return View(semiFinishedCar);
        }

        // POST: SemiFinishedCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.SemiFinishedCar == null)
            {
                return Problem("Entity set 'CarManufactoringContext.SemiFinishedCar'  is null.");
            }
            var semiFinishedCar = await _context.SemiFinishedCar.FindAsync(id);
            if (semiFinishedCar != null)
            {
                _context.SemiFinishedCar.Remove(semiFinishedCar);
                 await _context.SaveChangesAsync();
            }


            return View("SemiFinishedCarDeleted");
        }

        private bool SemiFinishedCarExists(int? id)
        {
          return _context.SemiFinishedCar.Any(e => e.SemiFinishedId == id);
        }
    }
}
