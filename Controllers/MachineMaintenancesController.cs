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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using CarManufactoring.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarManufactoring.Controllers
{
    [Authorize(Roles = "MaintenanceManager")]
    public class MachineMaintenancesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MachineMaintenancesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: MachineMaintenances
        public async Task<IActionResult> Index(int page = 0)
        {
            var all = _context.MachineMaintenance
            .Include(m => m.Priority)
            .Include(m => m.Machine)
            .Include(m => m.TaskType)
            .Include(m => m.Machine.MachineModel)
            .Include(m => m.Machine.MachineModel.MachineBrandNames)
            .Where(m => m.Deleted == false);
            
           

            var onProgress = await _context.MachineMaintenance
            .Include(m => m.Priority)
            .Include(m => m.Machine)
            .Include(m => m.TaskType)
            .Include(m => m.Machine.MachineModel)
            .Include(m => m.Machine.MachineModel.MachineBrandNames)
            .Where(m => !m.EffectiveEndDate.HasValue)
            .Where(m => m.Deleted == false).Take(10)
            .ToListAsync();

            var deleted = _context.MachineMaintenance
            .Include(m => m.Priority)
            .Include(m => m.Machine)
            .Include(m => m.TaskType)
            .Include(m => m.Machine.MachineModel)
            .Include(m => m.Machine.MachineModel.MachineBrandNames)
            .Where(m => !m.EffectiveEndDate.HasValue)
            .Where(m => m.Deleted == true);


            var pagingInfo = new PagingInfoViewModel(await all.CountAsync(), page);
            var pagingInfoDeleted = new PagingInfoViewModel(await deleted.CountAsync(), page);

            var model = new MachineMaintenaceIndexViewModel
            {

                All= new ListViewModel<MachineMaintenance>
                {
                    List = await all
                    .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                OnProgress = onProgress,
                Deleted = new ListViewModel<MachineMaintenance>
                {
                    List = await deleted
                    .Skip((pagingInfoDeleted.CurrentPage - 1) * pagingInfoDeleted.PageSize)
                    .Take(pagingInfoDeleted.PageSize).ToListAsync(),
                    PagingInfo = pagingInfoDeleted
                }
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

            var machineMaintenance = await _context.MachineMaintenance.
                Include(m => m.Machine.MachineModel.MachineBrandNames).
                FirstOrDefaultAsync(m => m.MachineMaintenanceId == id);


            if (machineMaintenance == null)
            {
                return NotFound();
            }

            ViewData["Collaborators"] = await _context.MaintenanceCollaborators.Include(c => c.Collaborators).Where(mc => mc.MachineMaintenanceId == id).ToListAsync();
            

                return View(machineMaintenance);
        }


        // GET: MachineMaintenances/Create
        public async Task<IActionResult> Create()
        {
            ViewData["TaskTypeId"] = new SelectList(_context.TaskType, "TaskTypeId", "TaskName");
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator.Include(c => c.MaintenanceCollaborators), "CollaboratorId", "Name");
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
        public async Task<IActionResult> Create(CrudMachineMaintenanceViewModel machineMaintenancePost )
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
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator.Include(c => c.MaintenanceCollaborators), "CollaboratorId", "Name");
            ViewData["PriorityId"] = new SelectList(_context.Priority, "PriorityId", "Name");

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
            CrudMachineMaintenanceViewModel machineMaintenanceViewModel = new CrudMachineMaintenanceViewModel();
            if (machineMaintenance != null)
            {
                machineMaintenanceViewModel.CastToMaintenaceCrud(machineMaintenance);
            }


            if (machineMaintenance == null)
            {
                return NotFound();
            }

            ViewData["TaskTypeId"] = new SelectList(_context.TaskType, "TaskTypeId", "TaskName");
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Name", machineMaintenanceViewModel.CollaboratorsId);
            ViewData["PriorityId"] = new SelectList(_context.Priority, "PriorityId", "Name");
            var machines = await _context.Machine.Include(m => m.MachineModel.MachineBrandNames).ToListAsync();

            ViewData["MachinesId"] = machines;
            return View(machineMaintenanceViewModel);
        }

        // POST: MachineMaintenances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CrudMachineMaintenanceViewModel machineMaintenancePost)
        {
            if (id != machineMaintenancePost.MachineMaintenanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                       //Começa-se por apagar as relações existentes na tabela de relacionamento Collaboratoes e Maintenance
                    var machineMaintenanceCollaboratorToDeleteList = await _context.MaintenanceCollaborators.Where(mc => mc.MachineMaintenanceId == id).ToListAsync();

                    foreach(MaintenanceCollaborator machineMaintenanceCollaboratorToDelete in machineMaintenanceCollaboratorToDeleteList)
                    {
                        _context.MaintenanceCollaborators.Remove(machineMaintenanceCollaboratorToDelete);
                        await _context.SaveChangesAsync();
                    }
                    

                    //Cria-se um novo objecto do tipo MachineMaintenance com a informação 
                    // actualizada  a guardar na base de dados

                    MachineMaintenance machineMaintenance = new MachineMaintenance();
                    machineMaintenance.MachineMaintenanceId = machineMaintenancePost.MachineMaintenanceId;
                    machineMaintenance.Description = machineMaintenancePost.Description;
                    machineMaintenance.PriorityId = machineMaintenancePost.PriorityId;
                    machineMaintenance.ExpectedEndDate = machineMaintenancePost.ExpectedEndDate;
                    machineMaintenance.MachineId = machineMaintenancePost.MachineId;
                    machineMaintenance.TaskTypeId = machineMaintenancePost.TaskTypeId;


                    _context.Update(machineMaintenance);
                    await _context.SaveChangesAsync();

                    //uma vez actualizada a manutenção volta-se adicionar as novas relações com os colaboradores
                    if (machineMaintenancePost.CollaboratorsId != null)
                    {

                        var machineMaintenanceCollaborators = await _context.MaintenanceCollaborators.Where(mc => mc.MachineMaintenanceId == id).ToListAsync();

                        MaintenanceCollaborator maintenanceCollaborator = new MaintenanceCollaborator();
                        //percorre-se um a um os colaboradores novos a actualizar
                        foreach (var updatedCollaboratorId in machineMaintenancePost.CollaboratorsId)
                        {

                              maintenanceCollaborator.CollaboratorId = updatedCollaboratorId;
                              maintenanceCollaborator.MachineMaintenanceId =machineMaintenancePost.MachineMaintenanceId;
                              _context.MaintenanceCollaborators.Add(maintenanceCollaborator);
                              await _context.SaveChangesAsync();
 
                        }


                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineMaintenanceExists(machineMaintenancePost.MachineMaintenanceId))
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
            ViewData["TaskTypeId"] = new SelectList(_context.TaskType, "TaskTypeId", "TaskName");
            ViewData["CollaboratorId"] = new SelectList(_context.Collaborator, "CollaboratorId", "Name");
            ViewData["PriorityId"] = new SelectList(_context.Priority, "PriorityId", "Name");

            var machines = await _context.Machine.Include(m => m.MachineModel.MachineBrandNames).ToListAsync();

            ViewData["MachinesId"] = machines;

            return View(machineMaintenancePost);
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
            //buscamos os colaboradores apagar
            var machineMaintenanceCollaborators = await _context.MaintenanceCollaborators.Where(m => m.MachineMaintenanceId == id).ToListAsync();
            var machineMaintenance = await _context.MachineMaintenance.FindAsync(id);
          

            if (machineMaintenance != null)
            {
                machineMaintenance.Deleted = true;

                await _context.SaveChangesAsync();

                //percorremos todos os colaboradores e modamos o estado para apagar
                foreach(var collaborator in machineMaintenanceCollaborators)
                {
                    collaborator.Deleted = true;
                    await _context.SaveChangesAsync();

                }
            }
            
            
            return RedirectToAction(nameof(Index));
        }

        private bool MachineMaintenanceExists(int id)
        {
          return _context.MachineMaintenance.Any(e => e.MachineMaintenanceId == id);
        }
    }
}
