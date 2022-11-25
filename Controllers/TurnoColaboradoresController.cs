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
    public class TurnoColaboradoresController : Controller
    {
        private readonly CarManufactoringContext _context;

        public TurnoColaboradoresController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: TurnoColaboradores
        public async Task<IActionResult> Index()
        {
              return View(await _context.TurnoColaboradores.ToListAsync());
        }

        // GET: TurnoColaboradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TurnoColaboradores == null)
            {
                return NotFound();
            }

            var turnoColaboradores = await _context.TurnoColaboradores
                .FirstOrDefaultAsync(m => m.TurnoColaboradoresId == id);
            if (turnoColaboradores == null)
            {
                return NotFound();
            }

            return View(turnoColaboradores);
        }

        // GET: TurnoColaboradores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TurnoColaboradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TurnoColaboradoresId,horas_turno,dataInicio,dataFim,turnoEstado,dataEstado")] TurnoColaboradores turnoColaboradores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turnoColaboradores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turnoColaboradores);
        }

        // GET: TurnoColaboradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TurnoColaboradores == null)
            {
                return NotFound();
            }

            var turnoColaboradores = await _context.TurnoColaboradores.FindAsync(id);
            if (turnoColaboradores == null)
            {
                return NotFound();
            }
            return View(turnoColaboradores);
        }

        // POST: TurnoColaboradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TurnoColaboradoresId,horas_turno,dataInicio,dataFim,turnoEstado,dataEstado")] TurnoColaboradores turnoColaboradores)
        {
            if (id != turnoColaboradores.TurnoColaboradoresId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turnoColaboradores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoColaboradoresExists(turnoColaboradores.TurnoColaboradoresId))
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
            return View(turnoColaboradores);
        }

        // GET: TurnoColaboradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TurnoColaboradores == null)
            {
                return NotFound();
            }

            var turnoColaboradores = await _context.TurnoColaboradores
                .FirstOrDefaultAsync(m => m.TurnoColaboradoresId == id);
            if (turnoColaboradores == null)
            {
                return NotFound();
            }

            return View(turnoColaboradores);
        }

        // POST: TurnoColaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TurnoColaboradores == null)
            {
                return Problem("Entity set 'CarManufactoringContext.TurnoColaboradores'  is null.");
            }
            var turnoColaboradores = await _context.TurnoColaboradores.FindAsync(id);
            if (turnoColaboradores != null)
            {
                _context.TurnoColaboradores.Remove(turnoColaboradores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoColaboradoresExists(int id)
        {
          return _context.TurnoColaboradores.Any(e => e.TurnoColaboradoresId == id);
        }
    }
}
