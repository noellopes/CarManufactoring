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


namespace CarManufactoring.Controllers
{
    public class ShiftTypesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public ShiftTypesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: ShiftTypes
        public async Task<IActionResult> Index(String ShiftTypeDescriptionSearched = null, int page = 0)
        {
            var shiftTypes = _context.ShiftType.Include(m => m.ShiftTypeSearch)
                .Where(m => ShiftTypeDescriptionSearched == null || m.Description.Contains(ShiftTypeDescriptionSearched)).OrderBy(m => m.StartTime)
                .OrderBy(m => m.StartTime);
            var pagingInfo = new PagingInfoViewModel(await shiftTypes.CountAsync(), page);
            var model = new ShiftTypeIndexViewModel
            {
                ShiftTypeList = new ListViewModel<ShiftType> {
                    List = await shiftTypes
                    .Skip((pagingInfo.CurrentPage - 1 ) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                ShiftTypeDescriptionSearched = ShiftTypeDescriptionSearched,
            };
              return View(model);
        }

        // GET: ShiftTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShiftType == null)
            {
                return NotFound();
            }

            var shiftType = await _context.ShiftType
                .FirstOrDefaultAsync(m => m.ShiftTypeId == id);
            if (shiftType == null)
            {
                return NotFound();
            }

            return View(shiftType);
        }

        // GET: ShiftTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShiftTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShiftTypeId,ShiftTime,Description,StartTime,EndTime")] ShiftType shiftType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shiftType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shiftType);
        }

        // GET: ShiftTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShiftType == null)
            {
                return NotFound();
            }

            var shiftType = await _context.ShiftType.FindAsync(id);
            if (shiftType == null)
            {
                return NotFound();
            }
            return View(shiftType);
        }

        // POST: ShiftTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShiftTypeId,ShiftTime,Description,StartTime,EndTime")] ShiftType shiftType)
        {
            if (id != shiftType.ShiftTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shiftType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftTypeExists(shiftType.ShiftTypeId))
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
            return View(shiftType);
        }

        // GET: ShiftTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShiftType == null)
            {
                return NotFound();
            }

            var shiftType = await _context.ShiftType
                .FirstOrDefaultAsync(m => m.ShiftTypeId == id);
            if (shiftType == null)
            {
                return NotFound();
            }

            return View(shiftType);
        }

        // POST: ShiftTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShiftType == null)
            {
                return Problem("Entity set 'CarManufactoringContext.ShiftType'  is null.");
            }
            var shiftType = await _context.ShiftType.FindAsync(id);
            if (shiftType != null)
            {
                _context.ShiftType.Remove(shiftType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShiftTypeExists(int id)
        {
          return _context.ShiftType.Any(e => e.ShiftTypeId == id);
        }
    }
}
