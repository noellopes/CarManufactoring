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
    public class MachineBrandsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MachineBrandsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: MachineBrands
        public async Task<IActionResult> Index()
        {
              return View(await _context.MachineBrand.ToListAsync());
        }

        // GET: MachineBrands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MachineBrand == null)
            {
                return NotFound();
            }

            var machineBrand = await _context.MachineBrand
                .FirstOrDefaultAsync(m => m.MachineBrandId == id);
            if (machineBrand == null)
            {
                return NotFound();
            }

            return View(machineBrand);
        }

        // GET: MachineBrands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MachineBrands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineBrandId,MachineBrandName")] MachineBrand machineBrand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machineBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(machineBrand);
        }

        // GET: MachineBrands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MachineBrand == null)
            {
                return NotFound();
            }

            var machineBrand = await _context.MachineBrand.FindAsync(id);
            if (machineBrand == null)
            {
                return NotFound();
            }
            return View(machineBrand);
        }

        // POST: MachineBrands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineBrandId,MachineBrandName")] MachineBrand machineBrand)
        {
            if (id != machineBrand.MachineBrandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machineBrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineBrandExists(machineBrand.MachineBrandId))
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
            return View(machineBrand);
        }

        // GET: MachineBrands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MachineBrand == null)
            {
                return NotFound();
            }

            var machineBrand = await _context.MachineBrand
                .FirstOrDefaultAsync(m => m.MachineBrandId == id);
            if (machineBrand == null)
            {
                return NotFound();
            }

            return View(machineBrand);
        }

        // POST: MachineBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MachineBrand == null)
            {
                return Problem("Entity set 'CarManufactoringContext.MachineBrand'  is null.");
            }
            var machineBrand = await _context.MachineBrand.FindAsync(id);
            if (machineBrand != null)
            {
                _context.MachineBrand.Remove(machineBrand);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineBrandExists(int id)
        {
          return _context.MachineBrand.Any(e => e.MachineBrandId == id);
        }
    }
}
