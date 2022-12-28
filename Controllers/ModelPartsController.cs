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
            var carManufactoringContext = _context.ModelParts.Include(m => m.CarConfig).Include(m => m.CarParts);
            return View(await carManufactoringContext.ToListAsync());
        }

        // GET: ModelParts/Details/5
        public async Task<IActionResult> Details(int? CarConfigId, int? ProductId)
        {

            if (CarConfigId == null || ProductId == null || _context.ModelParts == null)
            {
                return NotFound();
            }

            var modelParts = await _context.ModelParts
                .Include(m => m.CarConfig)
                .Include(m => m.CarParts)
                .FirstOrDefaultAsync(m => m.CarConfigId == CarConfigId && m.ProductId == ProductId);
            if (modelParts == null)
            {
                return NotFound();
            }

            return View(modelParts);
        }

        // GET: ModelParts/Create
        public IActionResult Create()
        {
            ViewData["CarConfigId"] = new SelectList(_context.CarConfig, "CarConfigId", "ConfigName");
            ViewData["ProductId"] = new SelectList(_context.CarParts, "ProductId", "Name");
            return View();
        }

        // POST: ModelParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,CarConfigId,QtdPecas")] ModelParts modelParts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelParts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarConfigId"] = new SelectList(_context.CarConfig, "CarConfigId", "ConfigName", modelParts.CarConfigId);
            ViewData["ProductId"] = new SelectList(_context.CarParts, "ProductId", "Name", modelParts.ProductId);
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
            ViewData["CarConfigId"] = new SelectList(_context.CarConfig, "CarConfigId", "ConfigName", modelParts.CarConfigId);
            ViewData["ProductId"] = new SelectList(_context.CarParts, "ProductId", "Name", modelParts.ProductId);
            return View(modelParts);
        }

        // POST: ModelParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,CarConfigId,QtdPecas")] ModelParts modelParts)
        {
            if (id != modelParts.ProductId)
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
                    if (!ModelPartsExists(modelParts.ProductId))
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
            ViewData["CarConfigId"] = new SelectList(_context.CarConfig, "CarConfigId", "ConfigName", modelParts.CarConfigId);
            ViewData["ProductId"] = new SelectList(_context.CarParts, "ProductId", "Name", modelParts.ProductId);
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
                .Include(m => m.CarConfig)
                .Include(m => m.CarParts)
                .FirstOrDefaultAsync(m => m.ProductId == id);
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
          return _context.ModelParts.Any(e => e.ProductId == id);
        }
    }
}
