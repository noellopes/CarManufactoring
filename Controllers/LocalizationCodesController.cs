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
    public class LocalizationCodesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public LocalizationCodesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: LocalizationCodes
        public async Task<IActionResult> Index(string Collumn = null)
        {
            var localizationcode = _context.LocalizationCode.OrderBy(b => b.Column).ThenBy(b => b.Line);
            return View(localizationcode);
        }

        // GET: LocalizationCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LocalizationCode == null)
            {
                return NotFound();
            }

            var localizationCode = await _context.LocalizationCode
                .FirstOrDefaultAsync(m => m.LocalizationCodeId == id);
            if (localizationCode == null)
            {
                return NotFound();
            }
            ViewBag.SuccessMessage = TempData["SuccessMessage"];

            return View(localizationCode);
        }

        // GET: LocalizationCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocalizationCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocalizationCodeId,Column,Line")] LocalizationCode localizationCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localizationCode);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Assigment created successfully.";

                return RedirectToAction(nameof(Details), new { id = localizationCode.LocalizationCodeId });
            }
            return View(localizationCode);
        }

        // GET: LocalizationCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LocalizationCode == null)
            {
                return NotFound();
            }

            var localizationCode = await _context.LocalizationCode.FindAsync(id);
            if (localizationCode == null)
            {
                return NotFound();
            }
            return View(localizationCode);
        }

        // POST: LocalizationCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocalizationCodeId,Column,Line")] LocalizationCode localizationCode)
        {
            if (id != localizationCode.LocalizationCodeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localizationCode);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Assigment created successfully.";

                    return RedirectToAction(nameof(Details), new { id = localizationCode.LocalizationCodeId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalizationCodeExists(localizationCode.LocalizationCodeId))
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
            return View(localizationCode);
        }

        // GET: LocalizationCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LocalizationCode == null)
            {
                return NotFound();
            }

            var localizationCode = await _context.LocalizationCode
                .FirstOrDefaultAsync(m => m.LocalizationCodeId == id);
            if (localizationCode == null)
            {
                return NotFound();
            }

            return View(localizationCode);
        }

        // POST: LocalizationCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LocalizationCode == null)
            {
                return Problem("Entity set 'CarManufactoringContext.LocalizationCode'  is null.");
            }
            var localizationCode = await _context.LocalizationCode.FindAsync(id);
            if (localizationCode != null)
            {
                _context.LocalizationCode.Remove(localizationCode);
                await _context.SaveChangesAsync();
            }

            return View("LocalizationCodeDeleted");
        }

        private bool LocalizationCodeExists(int id)
        {
          return _context.LocalizationCode.Any(e => e.LocalizationCodeId == id);
        }
    }
}
