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
    public class MaintenanceCollaboratorsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MaintenanceCollaboratorsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: MaintenanceCollaborators
        public async Task<IActionResult> Index()
        {
            var carManufactoringContext = _context.MaintenanceCollaborators.Include(m => m.Collaborators).Include(m => m.MaintenanceMachine);
            return View(await carManufactoringContext.ToListAsync());
        }

        // GET: MaintenanceCollaborators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MaintenanceCollaborators == null)
            {
                return NotFound();
            }

            var maintenanceCollaborator = await _context.MaintenanceCollaborators
                .Include(m => m.Collaborators)
                .Include(m => m.MaintenanceMachine)
                .FirstOrDefaultAsync(m => m.CollaboratorId == id);
            if (maintenanceCollaborator == null)
            {
                return NotFound();
            }

            return View(maintenanceCollaborator);
        }

        // GET: MaintenanceCollaborators/Create
        public IActionResult Create()
        {
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email");
            ViewData["MachineMaintenanceId"] = new SelectList(_context.MachineMaintenace, "MachineMaintenanceId", "Description");
            return View();
        }

        // POST: MaintenanceCollaborators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollaboratorId,MachineMaintenanceId,BeginDate,EffectiveEndDate,Deleted")] MaintenanceCollaborator maintenanceCollaborator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maintenanceCollaborator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", maintenanceCollaborator.CollaboratorId);
            ViewData["MachineMaintenanceId"] = new SelectList(_context.MachineMaintenace, "MachineMaintenanceId", "Description", maintenanceCollaborator.MachineMaintenanceId);
            return View(maintenanceCollaborator);
        }

        // GET: MaintenanceCollaborators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MaintenanceCollaborators == null)
            {
                return NotFound();
            }

            var maintenanceCollaborator = await _context.MaintenanceCollaborators.FindAsync(id);
            if (maintenanceCollaborator == null)
            {
                return NotFound();
            }
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", maintenanceCollaborator.CollaboratorId);
            ViewData["MachineMaintenanceId"] = new SelectList(_context.MachineMaintenace, "MachineMaintenanceId", "Description", maintenanceCollaborator.MachineMaintenanceId);
            return View(maintenanceCollaborator);
        }

        // POST: MaintenanceCollaborators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollaboratorId,MachineMaintenanceId,BeginDate,EffectiveEndDate,Deleted")] MaintenanceCollaborator maintenanceCollaborator)
        {
            if (id != maintenanceCollaborator.CollaboratorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maintenanceCollaborator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaintenanceCollaboratorExists(maintenanceCollaborator.CollaboratorId))
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
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Email", maintenanceCollaborator.CollaboratorId);
            ViewData["MachineMaintenanceId"] = new SelectList(_context.MachineMaintenace, "MachineMaintenanceId", "Description", maintenanceCollaborator.MachineMaintenanceId);
            return View(maintenanceCollaborator);
        }

        // GET: MaintenanceCollaborators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MaintenanceCollaborators == null)
            {
                return NotFound();
            }

            var maintenanceCollaborator = await _context.MaintenanceCollaborators
                .Include(m => m.Collaborators)
                .Include(m => m.MaintenanceMachine)
                .FirstOrDefaultAsync(m => m.CollaboratorId == id);
            if (maintenanceCollaborator == null)
            {
                return NotFound();
            }

            return View(maintenanceCollaborator);
        }

        // POST: MaintenanceCollaborators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MaintenanceCollaborators == null)
            {
                return Problem("Entity set 'CarManufactoringContext.MaintenanceCollaborators'  is null.");
            }
            var maintenanceCollaborator = await _context.MaintenanceCollaborators.FindAsync(id);
            if (maintenanceCollaborator != null)
            {
                _context.MaintenanceCollaborators.Remove(maintenanceCollaborator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaintenanceCollaboratorExists(int id)
        {
          return _context.MaintenanceCollaborators.Any(e => e.CollaboratorId == id);
        }
    }
}
