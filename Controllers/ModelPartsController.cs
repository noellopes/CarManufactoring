using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using CarManufactoring.ViewModels;

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
        public async Task<IActionResult> Index(string CarConfigName = null, string CarPartName = null, int QtdPecas = 0, int page = 1)
        {
            var empty = _context.ModelParts.Count();

            if (empty == 0)
            {
                return View("NoDataFound");
            }

            var ModelPartsVar = _context.ModelParts.Include(s => s.CarConfig).Include(s => s.CarParts)
                .Where(c => QtdPecas == 0 || c.QtdPecas.Equals(QtdPecas))
                .Where(c => CarConfigName == null || c.CarConfig.ConfigName.Contains(CarConfigName))
                .Where(c => CarPartName == null || c.CarParts.Name.Contains(CarPartName))
                .OrderBy(c => c.CarConfig.ConfigName);

            if(ModelPartsVar.Count() == 0)
            {
                ViewBag.ErrorMessage = "Not Found";
                return await Index(null, null, 0, page);
            }

            var PagingInfoVar = new PagingInfoViewModel(await ModelPartsVar.CountAsync(), page);

            PagingInfoVar.PageSize = 10;
            PagingInfoVar.Pages_Show_Before_After = 6;

            var model = new ModelPartsIndexViewModel
            {
                ModelPartsList = new ListViewModel<ModelParts>
                {
                    List = await ModelPartsVar
                    .Skip((PagingInfoVar.CurrentPage - 1) * PagingInfoVar.PageSize)
                    .Take(PagingInfoVar.PageSize).ToListAsync(),
                    PagingInfo = PagingInfoVar
                },
                QuantitySearched = QtdPecas,
                CarConfigNameSearched = CarConfigName,
                ModelPartsNameSearched = CarPartName,
                CarParts = _context.CarParts
                .OrderBy(c => c.Name).ToList(),
                CarConfigs = _context.CarConfig
                .OrderBy(c => c.ConfigName).ToList(),
            };
            return View(model);
            
            
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
        public async Task<IActionResult> Edit(int? CarConfigId, int? ProductId)
        {
            if (CarConfigId == null || ProductId == null || _context.ModelParts == null)
            {
                return NotFound();
            }

            var modelParts = await _context.ModelParts.FindAsync(CarConfigId, ProductId);
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
        public async Task<IActionResult> Edit(int CarConfigId, int ProductId, [Bind("ProductId,CarConfigId,QtdPecas")] ModelParts modelParts)
        {
            if (CarConfigId != modelParts.CarConfigId || ProductId != modelParts.ProductId)
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
                    if (!ModelPartsExists(modelParts.ProductId, modelParts.CarConfigId))
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
        public async Task<IActionResult> Delete(int? CarConfigId, int? ProductId)
        {
            if (CarConfigId == null || ProductId == null || _context.ModelParts == null)
            {
                return NotFound();
            }

            var modelParts = await _context.ModelParts
                .Include(m => m.CarConfig)
                .Include(m => m.CarParts)
                .FirstOrDefaultAsync(m => m.ProductId == ProductId && m.CarConfigId == CarConfigId);
            if (modelParts == null)
            {
                return NotFound();
            }

            return View(modelParts);
        }

        // POST: ModelParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int CarConfigId, int ProductId)
        {
            if (_context.ModelParts == null)
            {
                return Problem("Entity set 'CarManufactoringContext.ModelParts'  is null.");
            }
            var modelParts = await _context.ModelParts.Where(m => m.CarConfigId == CarConfigId && m.ProductId == ProductId).ToListAsync();
            if (modelParts != null)
            {
                _context.ModelParts.Remove(modelParts[0]);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelPartsExists(int ProductId, int CarConfigId)
        {
          return _context.ModelParts.Any(e => e.ProductId == ProductId && e.CarConfigId == CarConfigId);
        }
    }
}
