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
    public class CollaboratorsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public CollaboratorsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Collaborators
        public async Task<IActionResult> Index()
        {
              return View(await _context.Collaborator.ToListAsync());
        }

        // GET: Collaborators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Collaborator == null)
            {
                return NotFound();
            }

            var collaborator = await _context.Collaborator
                .FirstOrDefaultAsync(m => m.CollaboratorId == id);
            if (collaborator == null)
            {
                return NotFound();
            }

            return View(collaborator);
        }

        // GET: Collaborators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Collaborators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollaboratorId,Name,BirthDate,Phone,Email,Gender,OnDuty,Status")] Collaborator collaborator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collaborator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(collaborator);
        }

        // GET: Collaborators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Collaborator == null)
            {
                return NotFound();
            }

            var collaborator = await _context.Collaborator.FindAsync(id);
            if (collaborator == null)
            {
                return NotFound();
            }
            return View(collaborator);
        }

        // POST: Collaborators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollaboratorId,Name,BirthDate,Phone,Email,Gender,OnDuty,Status")] Collaborator collaborator)
        {
            if (id != collaborator.CollaboratorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collaborator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollaboratorExists(collaborator.CollaboratorId))
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
            return View(collaborator);
        }

        // GET: Collaborators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Collaborator == null)
            {
                return NotFound();
            }

            var collaborator = await _context.Collaborator
                .FirstOrDefaultAsync(m => m.CollaboratorId == id);
            if (collaborator == null)
            {
                return NotFound();
            }

            return View(collaborator);
        }

        // POST: Collaborators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Collaborator == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Collaborator'  is null.");
            }
            var collaborator = await _context.Collaborator.FindAsync(id);
            if (collaborator != null)
            {
                _context.Collaborator.Remove(collaborator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollaboratorExists(int id)
        {
          return _context.Collaborator.Any(e => e.CollaboratorId == id);
        }
    }
}
