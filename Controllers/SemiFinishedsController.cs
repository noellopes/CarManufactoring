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
    public class SemiFinishedsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public SemiFinishedsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: SemiFinisheds
        public async Task<IActionResult> Index()
        {
              return View(await _context.SemiFinished.ToListAsync());
        }

        // GET: SemiFinisheds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SemiFinished == null)
            {
                return NotFound();
            }

            var semiFinished = await _context.SemiFinished
                .FirstOrDefaultAsync(m => m.SemiFinishedId == id);
            if (semiFinished == null)
            {
                return NotFound();
            }

            return View(semiFinished);
        }

        // GET: SemiFinisheds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SemiFinisheds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SemiFinishedId,Family,Reference,EAN,Manufacter,Description,SemiFinishedState")] SemiFinished semiFinished)
        {
            if (ModelState.IsValid)
            {
                _context.Add(semiFinished);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(semiFinished);
        }

        // GET: SemiFinisheds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SemiFinished == null)
            {
                return NotFound();
            }

            var semiFinished = await _context.SemiFinished.FindAsync(id);
            if (semiFinished == null)
            {
                return NotFound();
            }
            return View(semiFinished);
        }

        // POST: SemiFinisheds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SemiFinishedId,Family,Reference,EAN,Manufacter,Description,SemiFinishedState")] SemiFinished semiFinished)
        {
            if (id != semiFinished.SemiFinishedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(semiFinished);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SemiFinishedExists(semiFinished.SemiFinishedId))
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
            return View(semiFinished);
        }

        // GET: SemiFinisheds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SemiFinished == null)
            {
                return NotFound();
            }

            var semiFinished = await _context.SemiFinished
                .FirstOrDefaultAsync(m => m.SemiFinishedId == id);
            if (semiFinished == null)
            {
                return NotFound();
            }

            return View(semiFinished);
        }

        // POST: SemiFinisheds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SemiFinished == null)
            {
                return Problem("Entity set 'CarManufactoringContext.SemiFinished'  is null.");
            }
            var semiFinished = await _context.SemiFinished.FindAsync(id);
            if (semiFinished != null)
            {
                _context.SemiFinished.Remove(semiFinished);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SemiFinishedExists(int id)
        {
          return _context.SemiFinished.Any(e => e.SemiFinishedId == id);
        }
    }
}
