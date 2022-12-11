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
    public class MachineModelsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MachineModelsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: MachineModels
        public async Task<IActionResult> Index()
        {
            var carManufactoringContext = _context.MachineModel.Include(m => m.MachineBrandNames);
            return View(await carManufactoringContext.ToListAsync());
        }

        // GET: MachineModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MachineModel == null)
            {
                return NotFound();
            }

            var machineModel = await _context.MachineModel
                .Include(m => m.MachineBrandNames)
                .FirstOrDefaultAsync(m => m.MachineModelId == id);
            if (machineModel == null)
            {
                return NotFound();
            }

            return View(machineModel);
        }

        // GET: MachineModels/Create
        public IActionResult Create()
        {
            ViewData["MachineBrandId"] = new SelectList(_context.MachineBrand, "MachineBrandId", "MachineBrandName");
            return View();
        }

        // POST: MachineModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineModelId,MachineModelName,MachineBrandId")] MachineModel machineModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machineModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MachineBrandId"] = new SelectList(_context.MachineBrand, "MachineBrandId", "MachineBrandName", machineModel.MachineBrandId);
            return View(machineModel);
        }

        // GET: MachineModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MachineModel == null)
            {
                return NotFound();
            }

            var machineModel = await _context.MachineModel.FindAsync(id);
            if (machineModel == null)
            {
                return NotFound();
            }
            ViewData["MachineBrandId"] = new SelectList(_context.MachineBrand, "MachineBrandId", "MachineBrandName", machineModel.MachineBrandId);
            return View(machineModel);
        }

        // POST: MachineModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineModelId,MachineModelName,MachineBrandId")] MachineModel machineModel)
        {
            if (id != machineModel.MachineModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machineModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineModelExists(machineModel.MachineModelId))
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
            ViewData["MachineBrandId"] = new SelectList(_context.MachineBrand, "MachineBrandId", "MachineBrandName", machineModel.MachineBrandId);
            return View(machineModel);
        }

        // GET: MachineModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MachineModel == null)
            {
                return NotFound();
            }

            var machineModel = await _context.MachineModel
                .Include(m => m.MachineBrandNames)
                .FirstOrDefaultAsync(m => m.MachineModelId == id);
            if (machineModel == null)
            {
                return NotFound();
            }

            return View(machineModel);
        }

        // POST: MachineModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MachineModel == null)
            {
                return Problem("Entity set 'CarManufactoringContext.MachineModel'  is null.");
            }
            var machineModel = await _context.MachineModel.FindAsync(id);
            if (machineModel != null)
            {
                _context.MachineModel.Remove(machineModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineModelExists(int id)
        {
          return _context.MachineModel.Any(e => e.MachineModelId == id);
        }
    }
}
