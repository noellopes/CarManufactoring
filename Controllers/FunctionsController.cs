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
    public class FunctionsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public FunctionsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Functions
        public async Task<IActionResult> Index(string Name = null)
        {
            var function = _context.Function.OrderBy(b => b.Name);
            return View(function);
        }

        // GET: Functions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Function == null)
            {
                return NotFound();
            }

            var function = await _context.Function
                .FirstOrDefaultAsync(m => m.FunctionId == id);
            if (function == null)
            {
                return NotFound();
            }
            ViewBag.SuccessMessage = TempData["SuccessMessage"];

            return View(function);
        }

        // GET: Functions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Functions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FunctionId,Name")] Function function)
        {
            if (ModelState.IsValid)
            {
                _context.Add(function);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Assigment created successfully.";

                return RedirectToAction(nameof(Details), new { id = function.FunctionId });
            }
            return View(function);
        }

        // GET: Functions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Function == null)
            {
                return NotFound();
            }

            var function = await _context.Function.FindAsync(id);
            if (function == null)
            {
                return NotFound();
            }
            return View(function);
        }

        // POST: Functions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FunctionId,Name")] Function function)
        {
            if (id != function.FunctionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(function);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Assigment created successfully.";

                    return RedirectToAction(nameof(Details), new { id = function.FunctionId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FunctionExists(function.FunctionId))
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
            return View(function);
        }

        // GET: Functions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Function == null)
            {
                return NotFound();
            }

            var function = await _context.Function
                .FirstOrDefaultAsync(m => m.FunctionId == id);
            if (function == null)
            {
                return NotFound();
            }

            return View(function);
        }

        // POST: Functions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Function == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Function'  is null.");
            }
            var function = await _context.Function.FindAsync(id);
            if (function != null)
            {
                _context.Function.Remove(function);
                await _context.SaveChangesAsync();
            }

            return View("FunctionDeleted");
        }

        private bool FunctionExists(int id)
        {
          return _context.Function.Any(e => e.FunctionId == id);
        }
    }
}
