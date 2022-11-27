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
              return View(await _context.Machines.ToListAsync());
        }

        // GET: Machines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Machines == null)
            {
                return NotFound();
            }

            var machines = await _context.Machines
                .FirstOrDefaultAsync(m => m.MachinesId == id);
            if (machines == null)
            {
                return NotFound();
            }

            return View(machines);
        }

        // GET: Machines/Create
        public IActionResult Create()
        {
            ViewData["MachineStateId"] = new SelectList(_context.Set<MachineState>(), "MachineStateId", "StateMachine");
            return View();
        }

        // POST: Machines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachinesId,MachineBrand,MachineModel,Available,AquisitionDate,MachineStateId")] Machines machines)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machines);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MachineStateId"] = new SelectList(_context.Set<MachineState>(), "MachineStateId", "StateMachine");
            return View(machines);
        }

        // GET: Machines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Machines == null)
            {
                return NotFound();
            }

            var machines = await _context.Machines.FindAsync(id);
            if (machines == null)
            {
                return NotFound();
            }
            ViewData["MachineStateId"] = new SelectList(_context.Set<MachineState>(), "MachineStateId", "StateMachine");
            return View(machines);
        }

        // POST: Machines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachinesId,MachineBrand,MachineModel,Available,AquisitionDate,MachineStateId")] Machines machines)
        {
            if (id != machines.MachinesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machines);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachinesExists(machines.MachinesId))
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
            ViewData["MachineStateId"] = new SelectList(_context.Set<MachineState>(), "MachineStateId", "StateMachine");
            return View(machines);
        }

        // GET: Machines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Machines == null)
            {
                return NotFound();
            }

            var machines = await _context.Machines
                .FirstOrDefaultAsync(m => m.MachinesId == id);
            if (machines == null)
            {
                return NotFound();
            }

            return View(machines);
        }

        // POST: Machines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Machines == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Machines'  is null.");
            }
            var machines = await _context.Machines.FindAsync(id);
            if (machines != null)
            {
                _context.Machines.Remove(machines);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachinesExists(int id)
        {
          return _context.Machines.Any(e => e.MachinesId == id);
        }
    }
}
