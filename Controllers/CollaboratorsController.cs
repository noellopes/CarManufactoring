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
using System.Xml.Linq;

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

        public async Task<IActionResult> Index(int Gender, int OnDuty, string Name = null, string Phone = null, int page = 0)
        {
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDefinition");

            IQueryable<Collaborator> collaborators = null;
            switch (OnDuty)
            {
                case 1:
                    collaborators = _context.Collaborator
                        .Include(c => c.Genders)
                        .Where(m => Name == null || m.Name.Contains(Name))
                        .Where(m => Phone == null || m.Phone.Contains(Phone))
                        .Where(m => m.OnDuty == true)
                        .OrderBy(m => m.Name);
                    break;

                case 2:
                    collaborators = _context.Collaborator
                        .Include(c => c.Genders)
                        .Where(m => Name == null || m.Name.Contains(Name))
                        .Where(m => Phone == null || m.Phone.Contains(Phone))
                        .Where(m => m.OnDuty == false)
                        .OrderBy(m => m.Name);
                    break;
                default:
                    collaborators = _context.Collaborator
                        .Include(c => c.Genders)
                        .Where(m => Name == null || m.Name.Contains(Name))
                        .Where(m => Phone == null || m.Phone.Contains(Phone))
                        .OrderBy(m => m.Name);
                    break;
            }
            // to Check if the gender id passed to search field exists & keep the code dynamic
            Gender SelectedGender = null;
            try
            {
                SelectedGender = _context.Gender.First(g => g.GenderId == Gender);

            }
            catch (Exception)
            {

            }
            if (Gender != 0 && SelectedGender != null)
            {
                collaborators = collaborators.Where(m => m.GenderId == Gender);
            }

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
                PhoneSearched = Phone,
                OnDutyFilter = OnDuty,
                GenderSearched = Gender,

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
                return View("CollaboratorNotFound");
            }

            ViewBag.SuccessMessage = TempData["SuccessMessage"];
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
                var duplicated = _context.Collaborator
                    .Include(c => c.Genders)
                    .Where(m => m.Name == collaborator.Name)
                    .Where(m => m.BirthDate == collaborator.BirthDate);
                if (await duplicated.CountAsync() == 0)
                {
                    _context.Add(collaborator);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Collaborator created successfully.";
                    return RedirectToAction(nameof(Details), new { id = collaborator.CollaboratorId });

                }
                else
                {
                    return View("DuplicateCollaborator",collaborator);
                }
            }
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDefinition", collaborator.GenderId);
            return View(collaborator);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDuplicte([Bind("CollaboratorId,Name,BirthDate,Phone,Email,GenderId,OnDuty,Status")] Collaborator duplicated)
        {
            _context.Add(duplicated);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Collaborator created successfully.";
            return RedirectToAction(nameof(Details), new { id = duplicated.CollaboratorId });
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
                return View("CollaboratorNotFound");
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
                    TempData["SuccessMessage"] = "Collaborator successfully edited.";
                    return RedirectToAction(nameof(Details), new { id = collaborator.CollaboratorId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollaboratorExists(collaborator.CollaboratorId))
                    {
                        return View("CollaboratorNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
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
                return View("CollaboratorNotFound");
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
                await _context.SaveChangesAsync();
            }

            return View("CollaboratorDeleted");
        }

        private bool CollaboratorExists(int id)
        {
          return _context.Collaborator.Any(e => e.CollaboratorId == id);
        }
    }
}
