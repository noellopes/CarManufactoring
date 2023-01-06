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
using CarManufactoring.ViewModels.Group6;
using Microsoft.AspNetCore.Authorization;

namespace CarManufactoring.Controllers
{
    [Authorize]
    public class SemiFinishedCarsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public SemiFinishedCarsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: SemiFinishedCars
        [AllowAnonymous]
        public async Task<IActionResult> Index(string reference = null, int page = 1)
        {
            var semifinishedCar = _context.SemiFinishedCar
                 .Include(s => s.SemiFinished)
                 .Include(s => s.Car.Brand)
                 .Where(s => reference == null || s.SemiFinished.Reference.Contains(reference))
                 .OrderBy(s => s.SemiFinished.Reference);


            var pagingInfo = new PagingInfoViewModel(await semifinishedCar.CountAsync(), page);


            var model = new SemiFinishedCarsIndexViewModel
            {
                SemiFinishedCarList = new ListViewModel<SemiFinishedCar>
                {
                    List = await semifinishedCar
                .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                ReferenceSearchedCar = reference

            };

            return View(model);
        }

        // GET: SemiFinishedCars/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SemiFinishedCar == null)
            {
                return NotFound();
            }

            var semiFinishedCar = await _context.SemiFinishedCar
                .Include(s => s.Car.Brand)
                .Include(s => s.SemiFinished)
                .FirstOrDefaultAsync(m => m.SemiFinishedCarId == id);
            if (semiFinishedCar == null)
            {
                return View("SemiFinishedCarNotFound");
            }
            ViewBag.SuccessMessage = TempData["SemiFinishedCar_SuccessMessage"];
            return View(semiFinishedCar);
        }

        // GET: SemiFinishedCars/Create
        [Authorize(Roles = "Admin,Colaborator,Manager")]
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
        [Authorize(Roles = "Admin,Colaborator,Manager")]
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
        [Authorize(Roles = "Admin,Colaborator,Manager")]
        public async Task<IActionResult> Edit([FromRoute] string CarId, [FromRoute] string SemiFinishedId)
        {
            if (!ModelState.IsValid || _context.SemiFinishedCar == null)
            {
                return NotFound();
            }

            var semiFinishedCar = await _context.SemiFinishedCar.FindAsync(CarId,SemiFinishedId);
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
        [Authorize(Roles = "Admin,Colaborator,Manager")]
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
                    return RedirectToAction(nameof(Details), new { id = semiFinishedCar.SemiFinishedCarId });
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
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SemiFinishedCar == null)
            {
                return NotFound();
            }

            var semiFinishedCar = await _context.SemiFinishedCar
                .Include(s => s.Car.Brand)
                .Include(s => s.SemiFinished)
                .FirstOrDefaultAsync(m => m.SemiFinishedCarId == id);
            if (semiFinishedCar == null)
            {
                return View("SemiFinishedCarNotFound");
            }

            return View(semiFinishedCar);
        }

        // POST: SemiFinishedCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] string CarId, [FromRoute] string SemiFinishedId)
        {
            if (_context.SemiFinishedCar == null)
            {
                return Problem("Entity set 'CarManufactoringContext.SemiFinishedCar'  is null.");
            }
            var semiFinishedCar = await _context.SemiFinishedCar.FindAsync(CarId,SemiFinishedId);
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
