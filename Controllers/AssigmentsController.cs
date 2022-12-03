using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using CarManufactoring.ViewModels;


namespace CarManufactoring.Controllers
{
    public class AssigmentsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public AssigmentsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Assigments
        public async Task<IActionResult> Index(string description = null, string state = null, DateTime limiteDate = default(DateTime))
        {

            var assigment = _context.Assigment.OrderBy(b => b.LimitDate);
            return View(assigment);

            
            
        }

        // GET: Assigments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assigment == null)
            {
                return NotFound();
            }

            var assigment = await _context.Assigment
                .FirstOrDefaultAsync(m => m.AssigmentId == id);
            if (assigment == null)
            {
                return NotFound();
            }

            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(assigment);
        }

        // GET: Assigments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assigments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssigmentId,Description,State,LimitDate")] Assigment assigment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assigment);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Assigment created successfully.";

                return RedirectToAction(nameof(Details),new {id = assigment.AssigmentId});
            }
            return View(assigment);
        }

        // GET: Assigments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assigment == null)
            {
                return NotFound();
            }

            var assigment = await _context.Assigment.FindAsync(id);
            if (assigment == null)
            {
                return NotFound();
            }
            return View(assigment);
        }

        // POST: Assigments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssigmentId,Description,State,LimitDate")] Assigment assigment)
        {
            if (id != assigment.AssigmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assigment);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Assigment created successfully.";

                    return RedirectToAction(nameof(Details), new { id = assigment.AssigmentId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssigmentExists(assigment.AssigmentId))
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
            return View(assigment);
        }

        // GET: Assigments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assigment == null)
            {
                return NotFound();
            }

            var assigment = await _context.Assigment
                .FirstOrDefaultAsync(m => m.AssigmentId == id);
            if (assigment == null)
            {
                return NotFound();
            }

            return View(assigment);
        }

        // POST: Assigments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assigment == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Assigment'  is null.");
            }
            var assigment = await _context.Assigment.FindAsync(id);
            if (assigment != null)
            {
                _context.Assigment.Remove(assigment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssigmentExists(int id)
        {
          return _context.Assigment.Any(e => e.AssigmentId == id);
        }
    }
}
