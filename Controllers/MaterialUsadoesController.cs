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
    public class MaterialUsadoesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MaterialUsadoesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: MaterialUsadoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.MaterialUsado.ToListAsync());
        }

        // GET: MaterialUsadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MaterialUsado == null)
            {
                return NotFound();
            }

            var materialUsado = await _context.MaterialUsado
                .FirstOrDefaultAsync(m => m.MaterialUsadoId == id);
            if (materialUsado == null)
            {
                return NotFound();
            }

            return View(materialUsado);
        }

        // GET: MaterialUsadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaterialUsadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaterialUsadoId,MaterialId,MaterialNome,SemiFinishedId,SemiFinishedNome")] MaterialUsado materialUsado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialUsado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialUsado);
        }

        // GET: MaterialUsadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MaterialUsado == null)
            {
                return NotFound();
            }

            var materialUsado = await _context.MaterialUsado.FindAsync(id);
            if (materialUsado == null)
            {
                return NotFound();
            }
            return View(materialUsado);
        }

        // POST: MaterialUsadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaterialUsadoId,MaterialId,MaterialNome,SemiFinishedId,SemiFinishedNome")] MaterialUsado materialUsado)
        {
            if (id != materialUsado.MaterialUsadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialUsado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialUsadoExists(materialUsado.MaterialUsadoId))
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
            return View(materialUsado);
        }

        // GET: MaterialUsadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MaterialUsado == null)
            {
                return NotFound();
            }

            var materialUsado = await _context.MaterialUsado
                .FirstOrDefaultAsync(m => m.MaterialUsadoId == id);
            if (materialUsado == null)
            {
                return NotFound();
            }

            return View(materialUsado);
        }

        // POST: MaterialUsadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MaterialUsado == null)
            {
                return Problem("Entity set 'CarManufactoringContext.MaterialUsado'  is null.");
            }
            var materialUsado = await _context.MaterialUsado.FindAsync(id);
            if (materialUsado != null)
            {
                _context.MaterialUsado.Remove(materialUsado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialUsadoExists(int id)
        {
          return _context.MaterialUsado.Any(e => e.MaterialUsadoId == id);
        }
    }
}
