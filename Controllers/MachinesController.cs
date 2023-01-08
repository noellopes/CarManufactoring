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
    public class MachinesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MachinesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Machines
        public async Task<IActionResult> Index()
        {
            var carManufactoringContext = _context.Machine.Include(m => m.MachineLocalizationCode).Include(m => m.MachineModel).Include(m => m.MachineState);
            return View(await carManufactoringContext.ToListAsync());
        }

        // GET: Machines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Machine == null)
            {
                return NotFound();
            }

            var machine = await _context.Machine
                .Include(m => m.MachineLocalizationCode)
                .Include(m => m.MachineModel)
                .Include(m => m.MachineState)
                .FirstOrDefaultAsync(m => m.MachineId == id);
            if (machine == null)
            {
                return NotFound();
            }

            return View(machine);
        }

        // GET: Machines/Create
        public IActionResult Create()
        {
            ViewData["LocalizationCodeId"] = new SelectList(_context.LocalizationCode, "LocalizationCodeId", "Column");
            ViewData["MachineModelId"] = new SelectList(_context.MachineModel, "MachineModelId", "MachineModelName");
            ViewData["MachineStateId"] = new SelectList(_context.MachineState, "MachineStateId", "StateMachine");
            return View();
        }

        // POST: Machines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineId,MachineModelId,MachineStateId,LocalizationCodeId,DateAcquired,Description")] Machine machine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalizationCodeId"] = new SelectList(_context.LocalizationCode, "LocalizationCodeId", "Column", machine.LocalizationCodeId);
            ViewData["MachineModelId"] = new SelectList(_context.MachineModel, "MachineModelId", "MachineModelName", machine.MachineModelId);
            ViewData["MachineStateId"] = new SelectList(_context.MachineState, "MachineStateId", "StateMachine", machine.MachineStateId);
            return View(machine);
        }

        // GET: Machines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Machine == null)
            {
                return NotFound();
            }

            var machine = await _context.Machine.FindAsync(id);
            if (machine == null)
            {
                return NotFound();
            }
            ViewData["LocalizationCodeId"] = new SelectList(_context.LocalizationCode, "LocalizationCodeId", "Column", machine.LocalizationCodeId);
            ViewData["MachineModelId"] = new SelectList(_context.MachineModel, "MachineModelId", "MachineModelName", machine.MachineModelId);
            ViewData["MachineStateId"] = new SelectList(_context.MachineState, "MachineStateId", "StateMachine", machine.MachineStateId);
            return View(machine);
        }

        // POST: Machines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineId,MachineModelId,MachineStateId,LocalizationCodeId,DateAcquired,Description")] Machine machine)
        {
            if (id != machine.MachineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineExists(machine.MachineId))
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
            ViewData["LocalizationCodeId"] = new SelectList(_context.LocalizationCode, "LocalizationCodeId", "Column", machine.LocalizationCodeId);
            ViewData["MachineModelId"] = new SelectList(_context.MachineModel, "MachineModelId", "MachineModelName", machine.MachineModelId);
            ViewData["MachineStateId"] = new SelectList(_context.MachineState, "MachineStateId", "StateMachine", machine.MachineStateId);
            return View(machine);
        }

        // GET: Machines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Machine == null)
            {
                return NotFound();
            }

            var machine = await _context.Machine
                .Include(m => m.MachineLocalizationCode)
                .Include(m => m.MachineModel)
                .Include(m => m.MachineState)
                .FirstOrDefaultAsync(m => m.MachineId == id);
            if (machine == null)
            {
                return NotFound();
            }

            return View(machine);
        }

        // POST: Machines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Machine == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Machine'  is null.");
            }
            var machine = await _context.Machine.FindAsync(id);
            if (machine != null)
            {
                _context.Machine.Remove(machine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineExists(int id)
        {
          return _context.Machine.Any(e => e.MachineId == id);
        }
    }
}
