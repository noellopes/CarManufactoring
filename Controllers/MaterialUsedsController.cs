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
    public class MaterialUsedsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MaterialUsedsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: MaterialUseds
        public async Task<IActionResult> Index()
        {
              return View(await _context.MaterialUsed.ToListAsync());
        }

        // GET: MaterialUseds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MaterialUsed == null)
            {
                return NotFound();
            }

            var materialUsed = await _context.MaterialUsed
                .FirstOrDefaultAsync(m => m.MaterialUsedId == id);
            if (materialUsed == null)
            {
                return NotFound();
            }

            return View(materialUsed);
        }

        // GET: MaterialUseds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaterialUseds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaterialUsedId,MaterialId,SemiFinishedId,Quantity")] MaterialUsed materialUsed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialUsed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialUsed);
        }

        // GET: MaterialUseds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MaterialUsed == null)
            {
                return NotFound();
            }

            var materialUsed = await _context.MaterialUsed.FindAsync(id);
            if (materialUsed == null)
            {
                return NotFound();
            }
            return View(materialUsed);
        }

        // POST: MaterialUseds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaterialUsedId,MaterialId,SemiFinishedId,Quantity")] MaterialUsed materialUsed)
        {
            if (id != materialUsed.MaterialUsedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialUsed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialUsedExists(materialUsed.MaterialUsedId))
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
            return View(materialUsed);
        }

        // GET: MaterialUseds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MaterialUsed == null)
            {
                return NotFound();
            }

            var materialUsed = await _context.MaterialUsed
                .FirstOrDefaultAsync(m => m.MaterialUsedId == id);
            if (materialUsed == null)
            {
                return NotFound();
            }

            return View(materialUsed);
        }

        // POST: MaterialUseds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MaterialUsed == null)
            {
                return Problem("Entity set 'CarManufactoringContext.MaterialUsed'  is null.");
            }
            var materialUsed = await _context.MaterialUsed.FindAsync(id);
            if (materialUsed != null)
            {
                _context.MaterialUsed.Remove(materialUsed);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialUsedExists(int id)
        {
          return _context.MaterialUsed.Any(e => e.MaterialUsedId == id);
        }
    }
}
