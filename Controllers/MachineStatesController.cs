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
    public class MachineStatesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MachineStatesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: MachineStates
        public async Task<IActionResult> Index()
        {
              return View(await _context.MachineState.ToListAsync());
        }

        // GET: MachineStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MachineState == null)
            {
                return NotFound();
            }

            var machineState = await _context.MachineState
                .FirstOrDefaultAsync(m => m.MachineStateId == id);
            if (machineState == null)
            {
                return NotFound();
            }

            return View(machineState);
        }

        // GET: MachineStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MachineStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineStateId,StateMachine")] MachineState machineState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machineState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(machineState);
        }

        // GET: MachineStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MachineState == null)
            {
                return NotFound();
            }

            var machineState = await _context.MachineState.FindAsync(id);
            if (machineState == null)
            {
                return NotFound();
            }
            return View(machineState);
        }

        // POST: MachineStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineStateId,StateMachine")] MachineState machineState)
        {
            if (id != machineState.MachineStateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machineState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineStateExists(machineState.MachineStateId))
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
            return View(machineState);
        }

        // GET: MachineStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MachineState == null)
            {
                return NotFound();
            }

            var machineState = await _context.MachineState
                .FirstOrDefaultAsync(m => m.MachineStateId == id);
            if (machineState == null)
            {
                return NotFound();
            }

            return View(machineState);
        }

        // POST: MachineStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MachineState == null)
            {
                return Problem("Entity set 'CarManufactoringContext.MachineState'  is null.");
            }
            var machineState = await _context.MachineState.FindAsync(id);
            if (machineState != null)
            {
                _context.MachineState.Remove(machineState);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineStateExists(int id)
        {
          return _context.MachineState.Any(e => e.MachineStateId == id);
        }
    }
}
