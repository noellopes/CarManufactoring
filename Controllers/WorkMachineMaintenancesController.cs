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
    public class WorkMachineMaintenancesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public WorkMachineMaintenancesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: WorkMachineMaintenances
        public async Task<IActionResult> Index()
        {
            var carManufactoringContext = _context.WorkMachineMaintenance.Include(w => w.Machines).Include(w => w.MaintenanceTask).Include(w => w.SectionManager).Include(w => w.WorkStates);
            return View(await carManufactoringContext.ToListAsync());
        }

        // GET: WorkMachineMaintenances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkMachineMaintenance == null)
            {
                return NotFound();
            }

            var workMachineMaintenance = await _context.WorkMachineMaintenance
                .Include(w => w.Machines)
                .Include(w => w.MaintenanceTask)
                .Include(w => w.SectionManager)
                .Include(w => w.WorkStates)
                .FirstOrDefaultAsync(m => m.WorkMachineMaintenanceId == id);
            if (workMachineMaintenance == null)
            {
                return NotFound();
            }

            return View(workMachineMaintenance);
        }

        // GET: WorkMachineMaintenance/Create
        public IActionResult Create()
        {
            ViewData["MachinesId"] = new SelectList(_context.Machines, "MachinesId", "MachineBrand");
            ViewData["MaintenanceTaskId"] = new SelectList(_context.MaintenanceTask, "MaintenanceTaskId", "TaskDef");
            ViewData["SectionManagerId"] = new SelectList(_context.SectionManager, "SectionManagerId", "Name");
            ViewData["WorkStatesId"] = new SelectList(_context.WorkStates, "WorkStatesId", "StateWork");
            return View();
        }

        // POST: WorkMachineMaintenances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkMachineMaintenanceId,MaintenanceStateDate,WorkPriority,Deleted,CreationDate,PreviewStartDate,MachinesId,SectionManagerId,MaintenanceTaskId,WorkStatesId")] WorkMachineMaintenance workMachineMaintenance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workMachineMaintenance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MachinesId"] = new SelectList(_context.Machines, "MachinesId", "MachineBrand", workMachineMaintenance.MachinesId);
            ViewData["MaintenanceTaskId"] = new SelectList(_context.MaintenanceTask, "MaintenanceTaskId", "TaskDef", workMachineMaintenance.MaintenanceTaskId);
            ViewData["SectionManagerId"] = new SelectList(_context.SectionManager, "SectionManagerId", "Name", workMachineMaintenance.SectionManagerId);
            ViewData["WorkStatesId"] = new SelectList(_context.WorkStates, "WorkStatesId", "StateWork", workMachineMaintenance.WorkStatesId);
            return View(workMachineMaintenance);
        }

        // GET: WorkMachineMaintenances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkMachineMaintenance == null)
            {
                return NotFound();
            }

            var workMachineMaintenance = await _context.WorkMachineMaintenance.FindAsync(id);
            if (workMachineMaintenance == null)
            {
                return NotFound();
            }
            ViewData["MachinesId"] = new SelectList(_context.Machines, "MachinesId", "MachineBrand", workMachineMaintenance.MachinesId);
            ViewData["MaintenanceTaskId"] = new SelectList(_context.MaintenanceTask, "MaintenanceTaskId", "TaskDef", workMachineMaintenance.MaintenanceTaskId);
            ViewData["SectionManagerId"] = new SelectList(_context.SectionManager, "SectionManagerId", "Name", workMachineMaintenance.SectionManagerId);
            ViewData["WorkStatesId"] = new SelectList(_context.WorkStates, "WorkStatesId", "StateWork", workMachineMaintenance.WorkStatesId);
            return View(workMachineMaintenance);
        }

        // POST: WorkMachineMaintenances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkMachineMaintenanceId,MaintenanceStateDate,WorkPriority,Deleted,CreationDate,PreviewStartDate,MachinesId,SectionManagerId,MaintenanceTaskId,WorkStatesId")] WorkMachineMaintenance workMachineMaintenance)
        {
            if (id != workMachineMaintenance.WorkMachineMaintenanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workMachineMaintenance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkMachineMaintenanceExists(workMachineMaintenance.WorkMachineMaintenanceId))
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
            ViewData["MachinesId"] = new SelectList(_context.Machines, "MachinesId", "MachineBrand", workMachineMaintenance.MachinesId);
            ViewData["MaintenanceTaskId"] = new SelectList(_context.MaintenanceTask, "MaintenanceTaskId", "TaskDef", workMachineMaintenance.MaintenanceTaskId);
            ViewData["SectionManagerId"] = new SelectList(_context.SectionManager, "SectionManagerId", "Name", workMachineMaintenance.SectionManagerId);
            ViewData["WorkStatesId"] = new SelectList(_context.WorkStates, "WorkStatesId", "StateWork", workMachineMaintenance.WorkStatesId);
            return View(workMachineMaintenance);
        }

        // GET: WorkMachineMaintenances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkMachineMaintenance == null)
            {
                return NotFound();
            }

            var workMachineMaintenance = await _context.WorkMachineMaintenance
                .Include(w => w.Machines)
                .Include(w => w.MaintenanceTask)
                .Include(w => w.SectionManager)
                .Include(w => w.WorkStates)
                .FirstOrDefaultAsync(m => m.WorkMachineMaintenanceId == id);
            if (workMachineMaintenance == null)
            {
                return NotFound();
            }

            return View(workMachineMaintenance);
        }

        // POST: WorkMachineMaintenances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkMachineMaintenance == null)
            {
                return Problem("Entity set 'CarManufactoringContext.WorkMachineMaintenance'  is null.");
            }
            var workMachineMaintenance = await _context.WorkMachineMaintenance.FindAsync(id);
            if (workMachineMaintenance != null)
            {
                _context.WorkMachineMaintenance.Remove(workMachineMaintenance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkMachineMaintenanceExists(int id)
        {
          return _context.WorkMachineMaintenance.Any(e => e.WorkMachineMaintenanceId == id);
        }
    }
}
