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
    public class WorkStatesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public WorkStatesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: WorkStates
        public async Task<IActionResult> Index()
        {
              return View(await _context.WorkStates.ToListAsync());
        }

        // GET: WorkStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkStates == null)
            {
                return NotFound();
            }

            var workStates = await _context.WorkStates
                .FirstOrDefaultAsync(m => m.WorkStatesId == id);
            if (workStates == null)
            {
                return NotFound();
            }

            return View(workStates);
        }

        // GET: WorkStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkStatesId,StateWork")] WorkStates workStates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workStates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workStates);
        }

        // GET: WorkStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkStates == null)
            {
                return NotFound();
            }

            var workStates = await _context.WorkStates.FindAsync(id);
            if (workStates == null)
            {
                return NotFound();
            }
            return View(workStates);
        }

        // POST: WorkStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkStatesId,StateWork")] WorkStates workStates)
        {
            if (id != workStates.WorkStatesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workStates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkStatesExists(workStates.WorkStatesId))
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
            return View(workStates);
        }

        // GET: WorkStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkStates == null)
            {
                return NotFound();
            }

            var workStates = await _context.WorkStates
                .FirstOrDefaultAsync(m => m.WorkStatesId == id);
            if (workStates == null)
            {
                return NotFound();
            }

            return View(workStates);
        }

        // POST: WorkStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkStates == null)
            {
                return Problem("Entity set 'CarManufactoringContext.WorkStates'  is null.");
            }
            var workStates = await _context.WorkStates.FindAsync(id);
            if (workStates != null)
            {
                _context.WorkStates.Remove(workStates);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkStatesExists(int id)
        {
          return _context.WorkStates.Any(e => e.WorkStatesId == id);
        }
    }
}
