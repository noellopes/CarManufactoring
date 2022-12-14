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
using Microsoft.AspNetCore.Authorization;

namespace CarManufactoring.Controllers
{
    [Authorize]
    public class InspectionAndTestsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public InspectionAndTestsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: InspectionAndTests
        [AllowAnonymous]
        public async Task<IActionResult> Index(string productions = null, string state = null, string collaborator = null, int page = 1)
        {
            var inspectionandtest = _context.InspectionAndTest.Include(s => s.Productions.CarConfig).Include(s => s.State).Include(s => s.Collaborator)
                .Where(s => productions == null || s.Productions.CarConfig.ConfigName.Contains(productions))
                .Where(s => state == null || s.State.State.Contains(state))
                .Where(s => collaborator == null || s.Collaborator.Name.Contains(collaborator))

            .OrderBy(s => s.StateId);

            var pagingInfo = new PagingInfoViewModel(await inspectionandtest.CountAsync(), page);

            var model = new InspectionTestIndexViewModel
            {
                InspectionAndTestList = new ListViewModel<InspectionAndTest>
                {
                    List = await inspectionandtest
                        .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                        .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                ProductionsSearched = productions,
                StateSearched = state,
                CollaboratorSearched = collaborator
            };

            return View(model);
        }

        // GET: InspectionAndTests/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InspectionAndTest == null)
            {
                return NotFound();
            }

            var inspectionAndTest = await _context.InspectionAndTest
                .Include(i => i.Collaborator)
                .Include(i => i.Productions)
                .Include(i => i.State)
                .FirstOrDefaultAsync(m => m.InspectionId == id);
            if (inspectionAndTest == null)
            {
                return NotFound();
            }


            return View(inspectionAndTest);
        }

        // GET: InspectionAndTests/Create
        [Authorize(Roles = "Admin, Manager, Colaborator")]
        public IActionResult Create()
        {
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Name");
            ViewData["ProductionsId"] = new SelectList(_context.Production, "ProductionId", "ProductionId");
            ViewData["StateId"] = new SelectList(_context.InspectionTestState, "InspectionTestStateId", "State");
            return View();
        }

        // POST: InspectionAndTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager, Colaborator")]
        public async Task<IActionResult> Create([Bind("InspectionId,ProductionsId,QuantityTested,StateId,Description,Date,CollaboratorId")] InspectionAndTest inspectionAndTest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspectionAndTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", inspectionAndTest.CollaboratorId);
            ViewData["ProductionsId"] = new SelectList(_context.Production, "ProductionId", "ProductionId", inspectionAndTest.ProductionsId);
            ViewData["StateId"] = new SelectList(_context.InspectionTestState, "InspectionTestStateId", "State", inspectionAndTest.StateId);
            return View(inspectionAndTest);
        }

        // GET: InspectionAndTests/Edit/5
        [Authorize(Roles = "Admin, Manager, Colaborator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InspectionAndTest == null)
            {
                return NotFound();
            }

            var inspectionAndTest = await _context.InspectionAndTest.FindAsync(id);
            if (inspectionAndTest == null)
            {
                return NotFound();
            }
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", inspectionAndTest.CollaboratorId);
            ViewData["ProductionsId"] = new SelectList(_context.Production, "ProductionId", "ProductionId", inspectionAndTest.ProductionsId);
            ViewData["StateId"] = new SelectList(_context.InspectionTestState, "InspectionTestStateId", "State", inspectionAndTest.StateId);
            return View(inspectionAndTest);
        }

        // POST: InspectionAndTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager, Colaborator")]
        public async Task<IActionResult> Edit(int id, [Bind("InspectionId,ProductionsId,QuantityTested,StateId,Description,Date,CollaboratorId")] InspectionAndTest inspectionAndTest)
        {
            if (id != inspectionAndTest.InspectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspectionAndTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspectionAndTestExists(inspectionAndTest.InspectionId))
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
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", inspectionAndTest.CollaboratorId);
            ViewData["ProductionsId"] = new SelectList(_context.Production, "ProductionId", "ProductionId", inspectionAndTest.ProductionsId);
            ViewData["StateId"] = new SelectList(_context.InspectionTestState, "InspectionTestStateId", "State", inspectionAndTest.StateId);
            return View(inspectionAndTest);
        }

        // GET: InspectionAndTests/Delete/5
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InspectionAndTest == null)
            {
                return NotFound();
            }

            var inspectionAndTest = await _context.InspectionAndTest
                .Include(i => i.Collaborator)
                .Include(i => i.Productions)
                .Include(i => i.State)
                .FirstOrDefaultAsync(m => m.InspectionId == id);
            if (inspectionAndTest == null)
            {
                return NotFound();
            }

            return View(inspectionAndTest);
        }

        // POST: InspectionAndTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InspectionAndTest == null)
            {
                return Problem("Entity set 'CarManufactoringContext.InspectionAndTest'  is null.");
            }
            var inspectionAndTest = await _context.InspectionAndTest.FindAsync(id);
            if (inspectionAndTest != null)
            {
                _context.InspectionAndTest.Remove(inspectionAndTest);
                await _context.SaveChangesAsync();
            }


            return View("InspectionTestDeleted");
        }

        private bool InspectionAndTestExists(int id)
        {
          return _context.InspectionAndTest.Any(e => e.InspectionId == id);
        }
    }
}
