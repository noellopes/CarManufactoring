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
    public class MachineAquisitionsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MachineAquisitionsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: MachineAquisitions
        public async Task<IActionResult> Index()
        {
              return View(await _context.MachineAquisition.ToListAsync());
        }

        // GET: MachineAquisitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MachineAquisition == null)
            {
                return NotFound();
            }

            var machineAquisition = await _context.MachineAquisition
                .FirstOrDefaultAsync(m => m.MachineAquisitionID == id);
            if (machineAquisition == null)
            {
                return NotFound();
            }

            return View(machineAquisition);
        }

        // GET: MachineAquisitions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MachineAquisitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineAquisitionID,MachineAquisitionName,Price,QuantityOfParts,ProducedParts,MaintenancePrice,Operation")] MachineAquisition machineAquisition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machineAquisition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(machineAquisition);
        }

        // GET: MachineAquisitions/Edit/5
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
            return View(machineAquisition);
        }

        // POST: MachineAquisitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineAquisitionID,MachineAquisitionName,Price,QuantityOfParts,ProducedParts,MaintenancePrice,Operation")] MachineAquisition machineAquisition)
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
            return View(machineAquisition);
        }

        // GET: MachineAquisitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MachineAquisition == null)
            {
                return NotFound();
            }

            var machineAquisition = await _context.MachineAquisition
                .FirstOrDefaultAsync(m => m.MachineAquisitionID == id);
            if (machineAquisition == null)
            {
                return NotFound();
            }

            return View(machineAquisition);
        }

        // POST: MachineAquisitions/Delete/5
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
