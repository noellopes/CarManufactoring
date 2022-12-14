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
using static System.Reflection.Metadata.BlobBuilder;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CarManufactoring.Controllers
{
    [Authorize]
    public class SemiFinishedsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public SemiFinishedsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: SemiFinisheds
        [AllowAnonymous]
        public async Task<IActionResult> Index(string state = null, string manufacter = null, string reference = null, string family = null,  int page = 1)
        {
            // order by  reference
            var semiFinisheds = _context.SemiFinished
                .Where(b => reference == null || b.Reference.Contains(reference))
                .Where(b => family == null || b.Family.Contains(family))
                
                .Where(b => manufacter == null || b.Manufacter.Contains(manufacter))
                .Where(b => state == null || b.SemiFinishedState.Contains(state))
                .OrderBy(b => b.Reference);

            var pagingInfo = new PagingInfoViewModel(await semiFinisheds.CountAsync(), page);


            var model = new SemiFinishedIndexViewModel
            {
                SemiFinishedList = new ListViewModel<SemiFinished>
                {
                    List = await semiFinisheds
                .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },

                FamilySearched = family,
                ReferenceSearched = reference,
                ManufacterSearched = manufacter,
                SemiFinishedStateSearched = state

            };

            return View(model);
        }

        // GET: SemiFinisheds/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SemiFinished == null)
            {
                return NotFound();
            }

            var semiFinished = await _context.SemiFinished
                .FirstOrDefaultAsync(m => m.SemiFinishedId == id);
            if (semiFinished == null)
            {
                return View("SemiFinishedNotFound");
            }

            ViewBag.SuccessMessage = TempData["SemiFinished_SuccessMessage"];

            return View(semiFinished);
        }

        // GET: SemiFinisheds/Create
        [Authorize(Roles = "Admin,Colaborator,Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SemiFinisheds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Colaborator,Manager")]

        public async Task<IActionResult> Create([Bind("SemiFinishedId,Family,Reference,Manufacter,Description,SemiFinishedState")] SemiFinished semiFinished)
        {
            if (ModelState.IsValid)
            {
                _context.Add(semiFinished);
                await _context.SaveChangesAsync();

                TempData["SemiFinished_SuccessMessage"] = "Semi Finished created successfully.";
                return RedirectToAction(nameof(Details), new { id = semiFinished.SemiFinishedId });
            }
            return View(semiFinished);
        }

        // GET: SemiFinisheds/Edit/5
        [Authorize(Roles = "Admin,Colaborator,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SemiFinished == null)
            {
                return NotFound();
            }

            var semiFinished = await _context.SemiFinished.FindAsync(id);
            if (semiFinished == null)
            {
                return View("SemiFinishedNotFound");
            }
            return View(semiFinished);
        }

        // POST: SemiFinisheds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Colaborator,Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("SemiFinishedId,Family,Reference,Manufacter,Description,SemiFinishedState")] SemiFinished semiFinished)
        {
            if (id != semiFinished.SemiFinishedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(semiFinished);
                    await _context.SaveChangesAsync();
                    TempData["SemiFinished_SuccessMessage"] = "Semi Finished Successfully Edited";
                    return RedirectToAction(nameof(Details), new { id = semiFinished.SemiFinishedId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SemiFinishedExists(semiFinished.SemiFinishedId))
                    {
                        return View("SemiFinishedNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(semiFinished);
        }

        // GET: SemiFinisheds/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SemiFinished == null)
            {
                return NotFound();
            }

            var semiFinished = await _context.SemiFinished
                .FirstOrDefaultAsync(m => m.SemiFinishedId == id);
            if (semiFinished == null)
            {
                return NotFound();
            }

            return View(semiFinished);
        }

        // POST: SemiFinisheds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SemiFinished == null)
            {
                return Problem("Entity set 'CarManufactoringContext.SemiFinished'  is null.");
            }
            var semiFinished = await _context.SemiFinished.FindAsync(id);
            if (semiFinished != null)
            {
                _context.SemiFinished.Remove(semiFinished);
                await _context.SaveChangesAsync();

            }

            return View("SemiFinishedDeleted");
        }

        private bool SemiFinishedExists(int id)
        {
          return _context.SemiFinished.Any(e => e.SemiFinishedId == id);
        }
    }
}
