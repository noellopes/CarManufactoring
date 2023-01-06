using CarManufactoring.Data;
using CarManufactoring.Models;
using CarManufactoring.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarManufactoring.Controllers
{
    public class ShiftScheduleController : Controller
    {
        private readonly CarManufactoringContext _context;

        public ShiftScheduleController(CarManufactoringContext context)
        {
            _context = context;
        }
        // GET: ShiftSchedule
        public async Task<IActionResult> Index(String collaborator = null, int quantity = 0, int page = 1)
        {
            var shiftSchedule = _context.ShiftSchedule.Include(s => s.Collaborator)
               .Where(c => collaborator == null || c.Collaborator.Name.Contains(collaborator));



            var pagingInfo = new PagingInfoViewModel(await shiftSchedule.CountAsync(), page);

            var model = new ShiftScheduleIndexViewModel
            {
                ShiftSchedules = new ListViewModel<ShiftSchedule>
                {
                    List = await shiftSchedule
                    .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo

                },
                CollaboratorSearched = collaborator,
                Collaborators = _context.Collaborator
            };

            return View(model);
        }
        // GET: ShiftSchedule/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShiftSchedule == null)
            {
                return NotFound();
            }

            var shiftSchedule = await _context.ShiftSchedule
                .Include(p => p.Collaborator)
                .FirstOrDefaultAsync(m => m.ShiftSchedulesId == id);
            if (shiftSchedule == null)
            {
                return NotFound();
            }

            return View(shiftSchedule);
        }
        // GET: ShiftSchedule/Create
        public IActionResult Create()
        {
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Name");
            return View();
        }

        // POST: Productions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,StartDate,EndDate,CollaboratorId")] ShiftSchedule shiftSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shiftSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollaboratorId"] = new SelectList(_context.ShiftSchedule, "CollaboratorId", "Name", shiftSchedule.CollaboratorId);
            return View(shiftSchedule);
        }
        // GET: ShiftSchedule/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShiftSchedule == null)
            {
                return NotFound();
            }

            var shiftSchedule = await _context.ShiftSchedule.FindAsync(id);
            if (shiftSchedule == null)
            {
                return NotFound();
            }
            ViewData["CollaboratorId"] = new SelectList(_context.ShiftSchedule, "CollaboratorId", "Name", shiftSchedule.CollaboratorId);
            return View(shiftSchedule);
        }
        // POST: ShiftSchedule/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,StartDate,EndDate,CollaboratorId")] ShiftSchedule shiftSchedule)
        {
            if (id != shiftSchedule.ShiftSchedulesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shiftSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchiftScheduleExists(shiftSchedule.ShiftSchedulesId))
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
            ViewData["CollaboratorId"] = new SelectList(_context.ShiftSchedule, "CollaboratorId", "Name", shiftSchedule.CollaboratorId);
            return View(shiftSchedule);
        }
        // GET: ShiftSchedule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShiftSchedule == null)
            {
                return NotFound();
            }

            var production = await _context.ShiftSchedule
                .Include(p => p.Collaborator)
                .FirstOrDefaultAsync(m => m.ShiftSchedulesId == id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        // POST: Productions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShiftSchedule == null)
            {
                return Problem("Entity set 'CarManufactoringContext.ShiftSchedule'  is null.");
            }
            var shiftSchedule = await _context.ShiftSchedule.FindAsync(id);
            if (shiftSchedule != null)
            {
                _context.ShiftSchedule.Remove(shiftSchedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool SchiftScheduleExists(int id)
        {
            return _context.ShiftSchedule.Any(e => e.ShiftSchedulesId == id);
        }
    }

}
