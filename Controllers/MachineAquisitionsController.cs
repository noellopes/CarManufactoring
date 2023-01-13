using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using CarManufactoring.ViewModels.Group4;
using CarManufactoring.ViewModels;
using System.Data;


namespace CarManufactoring.Controllers
{
    public class MachineAquisitionsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MachineAquisitionsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: MachineAquisitions
   
        public async Task<IActionResult> Index(string machineAquisitionName = null, int page = 1)
        {
            var machineAquisition = _context.MachineAquisition
              .Where(b => machineAquisitionName == null || b.MachineAquisitionName.Contains(machineAquisitionName))              
              .OrderBy(b => b.MachineAquisitionName);

            var pagingInfo = new PagingInfoViewModel(await machineAquisition.CountAsync(), page);

            try
            {
                var model = new MachineAquisitionsIndexViewModel
                {
                    MachineAquisitionsList = new ListViewModel<MachineAquisition>
                    {
                        List = await machineAquisition
                        .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                        .Take(pagingInfo.PageSize)
                        .Include(m => m.Machine)
                        .ToListAsync(),
                        PagingInfo = pagingInfo
                    },

                    MachineAquisitionNameSearch = machineAquisitionName


                };

                return View(model);

            }
            catch (Exception ex)
            {
                return await Index(null, page);
            }

        }

        // GET: MachineAquisitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MachineAquisition == null)
            {
                return NotFound();
            }

            var machineAquisition = await _context.MachineAquisition
                .Include(m => m.Machine)
                .FirstOrDefaultAsync(m => m.MachineAquisitionID == id);
            if (machineAquisition == null)
            {
                return NotFound();
            }

            return View(machineAquisition);
        }

        // GET: MachineAquisitions/Create
        //[Authorize(Roles = "Admin,Machineaqui")]
        public IActionResult Create()
        {
            ViewData["MachineId"] = new SelectList(_context.Machine, "MachineId", "Description");
            return View();
        }

        // POST: MachineAquisitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineAquisitionID,MachineAquisitionName,Price,QuantityOfParts,NextLevel,MaintenancePrice,MachineId")] MachineAquisition machineAquisition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machineAquisition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MachineId"] = new SelectList(_context.Machine, "MachineId", "Description", machineAquisition.MachineId);
            return View(machineAquisition);
        }

        // GET: MachineAquisitions/Edit/5
        //[Authorize(Roles = "Admin,Machineaqui")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MachineAquisition == null)
            {
                return NotFound();
            }

            var machineAquisition = await _context.MachineAquisition.FindAsync(id);
            if (machineAquisition == null)
            {
                return NotFound();
            }
            ViewData["MachineId"] = new SelectList(_context.Machine, "MachineId", "Description", machineAquisition.MachineId);
            return View(machineAquisition);
        }

        // POST: MachineAquisitions/Edit/5
        //[Authorize(Roles = "Admin,Machineaqui")]
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineAquisitionID,MachineAquisitionName,Price,QuantityOfParts,NextLevel,MaintenancePrice,MachineId")] MachineAquisition machineAquisition)
        {
            if (id != machineAquisition.MachineAquisitionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machineAquisition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineAquisitionExists(machineAquisition.MachineAquisitionID))
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
            ViewData["MachineId"] = new SelectList(_context.Machine, "MachineId", "Description", machineAquisition.MachineId);
            return View(machineAquisition);
        }

        // GET: MachineAquisitions/Delete/5
        //[Authorize(Roles = "Admin,Machineaqui")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MachineAquisition == null)
            {
                return NotFound();
            }

            var machineAquisition = await _context.MachineAquisition
                .Include(m => m.Machine)
                .FirstOrDefaultAsync(m => m.MachineAquisitionID == id);
            if (machineAquisition == null)
            {
                return NotFound();
            }

            return View(machineAquisition);
        }

        // POST: MachineAquisitions/Delete/5
        //[Authorize(Roles = "Admin,Machineaqui")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MachineAquisition == null)
            {
                return Problem("Entity set 'CarManufactoringContext.MachineAquisition'  is null.");
            }
            var machineAquisition = await _context.MachineAquisition.FindAsync(id);
            if (machineAquisition != null)
            {
                _context.MachineAquisition.Remove(machineAquisition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineAquisitionExists(int id)
        {
          return _context.MachineAquisition.Any(e => e.MachineAquisitionID == id);
        }
    }
}
