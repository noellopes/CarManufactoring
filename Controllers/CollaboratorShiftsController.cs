using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarManufactoring.Controllers
{
    [Authorize]
    public class CollaboratorShiftsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public CollaboratorShiftsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: CollaboratorShifts
        [Authorize(Roles = "ShiftManager, Colaborator")]
        public async Task<IActionResult> Index()
        {
            var carManufactoringContext = _context.CollaboratorShifts.Include(c => c.Collaborator).Include(c => c.Shift);
            return View(await carManufactoringContext.ToListAsync());
        }

        // GET: CollaboratorShifts/Details/5
        [Authorize(Roles = "ShiftManager, Colaborator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CollaboratorShifts == null)
            {
                return NotFound();
            }

            var collaboratorShifts = await _context.CollaboratorShifts
                .Include(c => c.Collaborator)
                .Include(c => c.Shift)
                .FirstOrDefaultAsync(m => m.CollaboratorShiftId == id);
            if (collaboratorShifts == null)
            {
                return NotFound();
            }

            return View(collaboratorShifts);
        }

        // GET: CollaboratorShifts/Create
        [Authorize(Roles = "ShiftManager")]
        public IActionResult Create()
        {
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Name");
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId");
            return View();
        }

        // POST: CollaboratorShifts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ShiftManager")]
        public async Task<IActionResult> Create([Bind("CollaboratorShiftId,EffectiveStartDate,EffectiveEndDate,ShiftId,CollaboratorId")] CollaboratorShifts collaboratorShifts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collaboratorShifts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", collaboratorShifts.CollaboratorId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", collaboratorShifts.ShiftId);
            return View(collaboratorShifts);
        }

        // GET: CollaboratorShifts/Edit/5
        [Authorize(Roles = "ShiftManager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CollaboratorShifts == null)
            {
                return NotFound();
            }

            var collaboratorShifts = await _context.CollaboratorShifts.FindAsync(id);
            if (collaboratorShifts == null)
            {
                return NotFound();
            }
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", collaboratorShifts.CollaboratorId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", collaboratorShifts.ShiftId);
            return View(collaboratorShifts);
        }

        // POST: CollaboratorShifts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "ShiftManager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollaboratorShiftId,EffectiveStartDate,EffectiveEndDate,ShiftId,CollaboratorId")] CollaboratorShifts collaboratorShifts)
        {
            if (id != collaboratorShifts.CollaboratorShiftId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collaboratorShifts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollaboratorShiftsExists(collaboratorShifts.CollaboratorShiftId))
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
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", collaboratorShifts.CollaboratorId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", collaboratorShifts.ShiftId);
            return View(collaboratorShifts);
        }

        // GET: CollaboratorShifts/Delete/5
        [Authorize(Roles = "ShiftManager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CollaboratorShifts == null)
            {
                return NotFound();
            }

            var collaboratorShifts = await _context.CollaboratorShifts
                .Include(c => c.Collaborator)
                .Include(c => c.Shift)
                .FirstOrDefaultAsync(m => m.CollaboratorId == id);
            if (collaboratorShifts == null)
            {
                return NotFound();
            }

            return View(collaboratorShifts);
        }

        // POST: CollaboratorShifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ShiftManager")]
        public async Task<IActionResult> DeleteConfirmed(int CollaboratorId, int ShiftId)
        {
            if (_context.CollaboratorShifts == null)
            {
                return Problem("Entity set 'CarManufactoringContext.CollaboratorShifts'  is null.");
            }
            var collaboratorShifts = await _context.CollaboratorShifts.FindAsync(CollaboratorId, ShiftId);
            if (collaboratorShifts != null)
            {
                _context.CollaboratorShifts.Remove(collaboratorShifts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollaboratorShiftsExists(int id)
        {
          return _context.CollaboratorShifts.Any(e => e.CollaboratorShiftId == id);
        }
    }
}
