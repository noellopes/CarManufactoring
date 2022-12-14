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
    public class SectionsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public SectionsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Sections
        public async Task<IActionResult> Index(string Name = null)
        {
            var section = _context.Section.OrderBy(b => b.Name);
            return View(section);
        }

        // GET: Sections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Section == null)
            {
                return NotFound();
            }

            var section = await _context.Section
                .FirstOrDefaultAsync(m => m.SectionId == id);
            if (section == null)
            {
                return NotFound();
            }
            ViewBag.SuccessMessage = TempData["SuccessMessage"];

            return View(section);
        }

        // GET: Sections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SectionId,Name")] Section section)
        {
            if (ModelState.IsValid)
            {
                _context.Add(section);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Assigment created successfully.";

                return RedirectToAction(nameof(Details), new { id = section.SectionId });
            }
            return View(section);
        }

        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Section == null)
            {
                return NotFound();
            }

            var section = await _context.Section.FindAsync(id);
            if (section == null)
            {
                return NotFound();
            }
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SectionId,Name")] Section section)
        {
            if (id != section.SectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(section);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Assigment created successfully.";

                    return RedirectToAction(nameof(Details), new { id = section.SectionId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionExists(section.SectionId))
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
            return View(section);
        }

        // GET: Sections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Section == null)
            {
                return NotFound();
            }

            var section = await _context.Section
                .FirstOrDefaultAsync(m => m.SectionId == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Section == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Section'  is null.");
            }
            var section = await _context.Section.FindAsync(id);
            if (section != null)
            {

                _context.Section.Remove(section);
                await _context.SaveChangesAsync();
            }

            return View("SectionDeleted");
            
        }

        private bool SectionExists(int id)
        {
          return _context.Section.Any(e => e.SectionId == id);
        }
    }
}
