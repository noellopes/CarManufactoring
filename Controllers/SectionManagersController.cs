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
    public class SectionManagersController : Controller
    {
        private readonly CarManufactoringContext _context;

        public SectionManagersController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: SectionManagers
        public async Task<IActionResult> Index()
        {
              return View(await _context.SectionManager.ToListAsync());
        }

        // GET: SectionManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SectionManager == null)
            {
                return NotFound();
            }

            var sectionManager = await _context.SectionManager
                .FirstOrDefaultAsync(m => m.SectionManagerId == id);
            if (sectionManager == null)
            {
                return NotFound();
            }

            return View(sectionManager);
        }

        // GET: SectionManagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SectionManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SectionManagerId,Name,BirthDate,Phone,Email,Section")] SectionManager sectionManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sectionManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sectionManager);
        }

        // GET: SectionManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SectionManager == null)
            {
                return NotFound();
            }

            var sectionManager = await _context.SectionManager.FindAsync(id);
            if (sectionManager == null)
            {
                return NotFound();
            }
            return View(sectionManager);
        }

        // POST: SectionManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SectionManagerId,Name,BirthDate,Phone,Email,Section")] SectionManager sectionManager)
        {
            if (id != sectionManager.SectionManagerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sectionManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionManagerExists(sectionManager.SectionManagerId))
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
            return View(sectionManager);
        }

        // GET: SectionManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SectionManager == null)
            {
                return NotFound();
            }

            var sectionManager = await _context.SectionManager
                .FirstOrDefaultAsync(m => m.SectionManagerId == id);
            if (sectionManager == null)
            {
                return NotFound();
            }

            return View(sectionManager);
        }

        // POST: SectionManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SectionManager == null)
            {
                return Problem("Entity set 'CarManufactoringContext.SectionManager'  is null.");
            }
            var sectionManager = await _context.SectionManager.FindAsync(id);
            if (sectionManager != null)
            {
                _context.SectionManager.Remove(sectionManager);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectionManagerExists(int id)
        {
          return _context.SectionManager.Any(e => e.SectionManagerId == id);
        }
    }
}
