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
    public class CollaboratorsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public CollaboratorsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Collaborators

        public async Task<IActionResult> Index(string Name = null, int page = 0)
        {
            var collaborators = _context.Collaborator
                .Include(c => c.Genders)
                .Where(m => Name == null || m.Name.Contains(Name))
                .OrderBy(m => m.Name);
            var pagingInfo = new PagingInfoViewModel(await collaborators.CountAsync(), page);

            var model = new CollaboratorIndexViewModel
            {
                collaboratorList = new ListViewModel<Collaborator>
                {
                    List = await collaborators
                    .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                NameSearched = Name,
            };
            return View(model);
        }

        // GET: Collaborators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Collaborator == null)
            {
                return NotFound();
            }

            var collaborator = await _context.Collaborator
                .Include(c => c.Genders)
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
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDefinition");
            return View();
        }

        // POST: Collaborators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollaboratorId,Name,BirthDate,Phone,Email,GenderId,OnDuty,Status")] Collaborator collaborator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collaborator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDefinition", collaborator.GenderId);
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
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDefinition", collaborator.GenderId);
            return View(collaborator);
        }

        // POST: Collaborators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollaboratorId,Name,BirthDate,Phone,Email,GenderId,OnDuty,Status")] Collaborator collaborator)
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
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDefinition", collaborator.GenderId);
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
                .Include(c => c.Genders)
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
