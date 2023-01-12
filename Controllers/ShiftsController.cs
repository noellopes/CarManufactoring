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
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Drawing;

namespace CarManufactoring.Controllers
{
    public class ShiftsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public ShiftsController(CarManufactoringContext context)
        {
            _context = context;
        }

     

        // GET: Shifts
        public async Task<IActionResult> Index( string shiftType = null, int page = 0)
        {
            var shifts = _context.Shift.Include(m => m.ShiftType)
                .Where(m => shiftType == null || m.ShiftType.Description.Contains(shiftType))
                .OrderBy(m => m.StartDate);
            var pagingInfo = new PagingInfoViewModel(await shifts.CountAsync(), page);

            var model = new ShiftIndexViewModel
            {
                ShiftList = new ListViewModel<Shift>
                {
                    List = await shifts
                    .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                ShiftTypeSearched = shiftType,
            };
            return View(model);
        }

        // GET: Shifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shift == null)
            {
                return NotFound();
            }

            var shift = await _context.Shift
                .Include(s => s.ShiftType)
                .FirstOrDefaultAsync(m => m.ShiftId == id);
            if (shift == null)
            {
                return View("ShiftNotFound");
            }

            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(shift);
        }

        // GET: Shifts/Create
        public IActionResult Create()
        {
            ViewData["ShiftTypeId"] = new SelectList(_context.ShiftType, "ShiftTypeId", "Description");
            return View();
        }

        // POST: Shifts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShiftId,StartDate,EndDate,ShiftTypeId")] Shift shift)
        {
            var valor = DateTime.Compare(shift.EndDate, shift.StartDate);
            if(valor < 0 || valor == 0) {
                ModelState.AddModelError("EndDate", "End Date can not be before Start Date.");
            }
            else{
                if (ModelState.IsValid)
                {
                    _context.Add(shift);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Shift created successfully.";

                    return RedirectToAction(nameof(Details), new { id = shift.ShiftId });
                }
            }
            
            ViewData["ShiftTypeId"] = new SelectList(_context.ShiftType, "ShiftTypeId", "Description", shift.ShiftTypeId);
            return View(shift);
        }

        // GET: Shifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shift == null)
            {
                return NotFound();
            }

            var shift = await _context.Shift.FindAsync(id);
            if (shift == null)
            {
                View("ShiftNotFound");
            }
            ViewData["ShiftTypeId"] = new SelectList(_context.ShiftType, "ShiftTypeId", "Description", shift.ShiftTypeId);
            return View(shift);
        }

        // POST: Shifts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShiftId,StartDate,EndDate,ShiftTypeId")] Shift shift)
        {
            if (id != shift.ShiftId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shift);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Shift edited successfully.";
                    return RedirectToAction(nameof(Details), new { id = shift.ShiftId });

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftExists(shift.ShiftId))
                    {
                        View("ShiftNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShiftTypeId"] = new SelectList(_context.ShiftType, "ShiftTypeId", "Description", shift.ShiftTypeId);
            return View(shift);
        }

        // GET: Shifts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shift == null)
            {
                return NotFound();
            }

            var shift = await _context.Shift
                .Include(s => s.ShiftType)
                .FirstOrDefaultAsync(m => m.ShiftId == id);
            if (shift == null)
            {
                return View("ShiftNotFound");
            }

            return View(shift);
        }

        // POST: Shifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shift == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Shift'  is null.");
            }
            var shift = await _context.Shift.FindAsync(id);
            if (shift != null)
            {
                _context.Shift.Remove(shift);
                await _context.SaveChangesAsync();
            }


            return View("ShiftDeleted");
        }
        public IActionResult CreateShifts()
        {
            ViewData["ShiftTypeId"] = new SelectList(_context.ShiftType, "ShiftTypeId", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateShifts([Bind("ShiftId,StartDate,EndDate,ShiftTypeId,Month,Year")] Shift shift)
        {
            var anoCompare = System.DateTime.Now.Year;
            var terminologia = "";
            var year = shift.Year;
            var month = shift.Month;

            switch (month)
            {
                case 1:
                    terminologia = "January";
                    break;
                case 2:
                    terminologia = "February";
                    break;
                case 3:
                    terminologia = "March";
                    break;
                case 4:
                    terminologia = "April";
                    break;
                case 5:
                    terminologia = "May";
                    break;
                case 6:
                    terminologia = "June";
                    break;
                case 7:
                    terminologia = "July";
                    break;
                case 8:
                    terminologia = "August";
                    break;
                case 9:
                    terminologia = "September";
                    break;
                case 10:
                    terminologia = "October";
                    break;
                case 11:
                    terminologia = "November";
                    break;
                case 12:
                    terminologia = "December";
                    break;
            }

            if (shift.Year < anoCompare)
            {
                ModelState.AddModelError("Year", $"Year can not be before {anoCompare}.");
            }
            int days = DateTime.DaysInMonth(year, month);

            

            if (ModelState.IsValid)
            {
                for(int i = 1; i <= days; i++) { 
                    var horas = 8;
                    for (int j = 1; j < 4; j++)
                    {
                        shift = new Shift();
                        shift.StartDate = new DateTime(year, month, i, horas, 00, 00);
                        if (horas > 17)
                        {
                            horas = 0;
                        }
                        else
                        {
                            horas += 6;
                        }
                        shift.EndDate = new DateTime(year, month, i, horas, 00, 00);
                        shift.ShiftTypeId = j;
                        horas -= 6;
                        if(horas < 16){ 
                            horas += 8;
                        }
                        else
                        {
                            horas += 2;
                        }
                    
                        _context.Add(shift);
                        await _context.SaveChangesAsync();
                    }
                }

                TempData["SuccessMessage"] = $"All the Shifts for the month of {terminologia} for the year {year} were successfully created .";
                ViewBag.SuccessMessage = TempData["SuccessMessage"];

                return View ("DetailsMonthShifts");

            }

            ViewData["ShiftTypeId"] = new SelectList(_context.ShiftType, "ShiftTypeId", "Description", shift.ShiftTypeId);
            return View(shift);
        }


        private bool ShiftExists(int id)
        {
          return _context.Shift.Any(e => e.ShiftId == id);
        }
    }
}
