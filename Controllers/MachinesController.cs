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
            var carManufactoringContext = _context.Machine.Include(m => m.MachineState).Include(m => m.Section);
            return View(await carManufactoringContext.ToListAsync());
        }

        // GET: Machines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Machine == null)
            {
                return NotFound();
            }

            var machines = await _context.Machine
                .Include(m => m.MachineState)
                .Include(m => m.Section)
                .FirstOrDefaultAsync(m => m.MachineId == id);
            if (machines == null)
            {
                return NotFound();
            }

            return View(machines);
        }

        // GET: Machines/Create
        public IActionResult Create()
        {
            ViewData["MachineStateId"] = new SelectList(_context.MachineState, "MachineStateId", "StateMachine");
            ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "Name");
            return View();
        }

        // POST: Machines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachinesId,MachineBrand,MachineModel,Available,AquisitionDate,MachineStateId,SectionId")] Machine machines)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machines);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MachineStateId"] = new SelectList(_context.MachineState, "MachineStateId", "StateMachine", machines.MachineStateId);
            ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "Name", machines.SectionId);
            return View(machines);
        }

        // GET: Machines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Machine == null)
            {
                return NotFound();
            }

            var machines = await _context.Machine.FindAsync(id);
            if (machines == null)
            {
                return NotFound();
            }
            ViewData["MachineStateId"] = new SelectList(_context.MachineState, "MachineStateId", "StateMachine", machines.MachineStateId);
            ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "Name", machines.SectionId);
            return View(machines);
        }

        // POST: Machines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachinesId,MachineBrand,MachineModel,Available,AquisitionDate,MachineStateId,SectionId")] Machine machines)
        {
            if (id != machines.MachineId)
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
                    if (!MachinesExists(machines.MachineId))
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
            ViewData["MachineStateId"] = new SelectList(_context.MachineState, "MachineStateId", "StateMachine", machines.MachineStateId);
            ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "Name", machines.SectionId);
            return View(machines);
        }

        // GET: Machines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Machine == null)
            {
                return NotFound();
            }

            var machines = await _context.Machine
                .Include(m => m.MachineState)
                .Include(m => m.Section)
                .FirstOrDefaultAsync(m => m.MachineId == id);
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
            if (_context.Machine == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Machines'  is null.");
            }
            var machines = await _context.Machine.FindAsync(id);
            if (machines != null)
            {
                _context.Machine.Remove(machines);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachinesExists(int id)
        {
          return _context.Machine.Any(e => e.MachineId == id);
        }
    }
}
