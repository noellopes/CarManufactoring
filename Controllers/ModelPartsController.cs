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
    public class ModelPartsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public ModelPartsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: ModelParts
        public async Task<IActionResult> Index()
        {
              return View(await _context.ModelParts.ToListAsync());
        }

        // GET: ModelParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModelParts == null)
            {
                return NotFound();
            }

            var modelParts = await _context.ModelParts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelParts == null)
            {
                return NotFound();
            }

            return View(modelParts);
        }

        // GET: ModelParts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModelParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PecaId,ModeloId,QtdPecas")] ModelParts modelParts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelParts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelParts);
        }

        // GET: ModelParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModelParts == null)
            {
                return NotFound();
            }

            var modelParts = await _context.ModelParts.FindAsync(id);
            if (modelParts == null)
            {
                return NotFound();
            }
            return View(modelParts);
        }

        // POST: ModelParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PecaId,ModeloId,QtdPecas")] ModelParts modelParts)
        {
            if (id != modelParts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelParts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelPartsExists(modelParts.Id))
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
            return View(modelParts);
        }

        // GET: ModelParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModelParts == null)
            {
                return NotFound();
            }

            var modelParts = await _context.ModelParts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelParts == null)
            {
                return NotFound();
            }

            return View(modelParts);
        }

        // POST: ModelParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModelParts == null)
            {
                return Problem("Entity set 'CarManufactoringContext.ModelParts'  is null.");
            }
            var modelParts = await _context.ModelParts.FindAsync(id);
            if (modelParts != null)
            {
                _context.ModelParts.Remove(modelParts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelPartsExists(int id)
        {
          return _context.ModelParts.Any(e => e.Id == id);
        }
    }
}
