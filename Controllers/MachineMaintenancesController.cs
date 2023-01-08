using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using CarManufactoring.ViewModels.Group1;
using System.Diagnostics;

namespace CarManufactoring.Controllers
{
    public class MachineMaintenancesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MachineMaintenancesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: MachineMaintenances
        public async Task<IActionResult> Index()
        {
            var all = await _context.MachineMaintenance
            .Include(m => m.Priority)
            .Include(m => m.Machine)
            .Include(m => m.TaskType)
            .Include(m => m.Machine.MachineModel)
            .Where(m => m.Deleted == false)
            .Include(m => m.Machine.MachineModel.MachineBrandNames)
            .ToListAsync();

            var onProgress = await _context.MachineMaintenance
            .Include(m => m.Priority)
            .Include(m => m.Machine)
            .Include(m => m.TaskType)
            .Include(m => m.Machine.MachineModel)
            .Include(m => m.Machine.MachineModel.MachineBrandNames)
            .Where(m => !m.EffectiveEndDate.HasValue)
            .Where(m => m.Deleted == false)
            .ToListAsync();
            

            var model = new MachineMaintenaceIndexViewModel
            {
                All = all,
                OnProgress = onProgress
            };

            return View(model);
        }

        // GET: MachineMaintenances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MachineMaintenance == null)
            {
                return NotFound();
            }

            var machineMaintenance = await _context.MachineMaintenance
                .FirstOrDefaultAsync(m => m.MachineMaintenanceId == id);
            if (machineMaintenance == null)
            {
                return NotFound();
            }

            return View(machineMaintenance);
        }

        
        public IActionResult CollaboratorGetMaintenance(int? id)
        {
            
            return View();
        }

        // GET: MachineMaintenances/Create
        public async Task<IActionResult> Create()
        {
            ViewData["TaskTypeId"] = new SelectList(_context.TaskType, "TaskTypeId", "TaskName");
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Name");
            ViewData["PriorityId"] = new SelectList(_context.Priority, "PriorityId", "Name");

            var machines = await  _context.Machine.Include(m => m.MachineModel.MachineBrandNames).ToListAsync();

            ViewData["MachinesId"] = machines;
            return View();
        }

        // POST: MachineMaintenances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMachineMaintenanceViewModel machineMaintenancePost )
        {

            if (ModelState.IsValid)
            {
        
                MachineMaintenance machineMaintenance = new MachineMaintenance();

                machineMaintenance.Description = machineMaintenancePost.Description;
                machineMaintenance.PriorityId = machineMaintenancePost.PriorityId;
                machineMaintenance.ExpectedEndDate = machineMaintenancePost.ExpectedEndDate;
                machineMaintenance.MachineId = machineMaintenancePost.MachineId;
                machineMaintenance.TaskTypeId = machineMaintenancePost.TaskTypeId;

                _context.Add(machineMaintenance);
                await _context.SaveChangesAsync();
                if(machineMaintenancePost.CollaboratorsId != null ){
                    foreach (int collaboratorId in machineMaintenancePost.CollaboratorsId)
                    {
                        MaintenanceCollaborator maintenanceCollaborator = new MaintenanceCollaborator();
                        maintenanceCollaborator.CollaboratorId = collaboratorId;
                        maintenanceCollaborator.MachineMaintenanceId =                      machineMaintenance.MachineMaintenanceId;
                        _context.Add(maintenanceCollaborator);
                        await _context.SaveChangesAsync();
                    }
                }
                
                return RedirectToAction(nameof(Index));
            }

            ViewData["TaskTypeId"] = new SelectList(_context.TaskType, "TaskTypeId", "TaskName");
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Name");


            var machines = await _context.Machine.Include(m => m.MachineModel.MachineBrandNames).ToListAsync();

            ViewData["MachinesId"] = machines;
            return View(machineMaintenancePost);
        }

        // GET: MachineMaintenances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MachineMaintenance == null)
            {
                return NotFound();
            }

            var machineMaintenance = await _context.MachineMaintenance.FindAsync(id);
            if (machineMaintenance == null)
            {
                return NotFound();
            }
            return View(machineMaintenance);
        }

        // POST: MachineMaintenances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineMaintenanceId,Description,Deleted,BeginDate,Effective_End_Date,Expected_End_Date")] MachineMaintenance machineMaintenance)
        {
            if (id != machineMaintenance.MachineMaintenanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machineMaintenance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineMaintenanceExists(machineMaintenance.MachineMaintenanceId))
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
            return View(machineMaintenance);
        }

        // GET: MachineMaintenances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MachineMaintenance == null)
            {
                return NotFound();
            }

            var machineMaintenance = await _context.MachineMaintenance
                .FirstOrDefaultAsync(m => m.MachineMaintenanceId == id);
            if (machineMaintenance == null)
            {
                return NotFound();
            }

            return View(machineMaintenance);
        }

        // POST: MachineMaintenances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MachineMaintenance == null)
            {
                return Problem("Entity set 'CarManufactoringContext.MachineMaintenance'  is null.");
            }
            var machineMaintenance = await _context.MachineMaintenance.FindAsync(id);
            if (machineMaintenance != null)
            {
                _context.MachineMaintenance.Remove(machineMaintenance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineMaintenanceExists(int id)
        {
          return _context.MachineMaintenance.Any(e => e.MachineMaintenanceId == id);
        }
    }
}
