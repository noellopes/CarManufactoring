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
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace CarManufactoring.Controllers
{
    public class ProductionsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public ProductionsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Productions
        public async Task<IActionResult> Index(String carConfig = null, int quantity = 0, int page = 1)
        {
            var empty = _context.Production.Count();

            if (empty == 0)
            {
                return View("NoDataFound");
            }
            var production = _context.Production.Include(s => s.CarConfig)
                .Where(c => carConfig == null || c.CarConfig.ConfigName.Contains(carConfig))
                .Where(c => quantity == 0 || c.Quantity.Equals(quantity));

            var pagingInfo = new PagingInfoViewModel(await production.CountAsync(), page);

            var lista = (from p in _context.Production
                         join t in _context.TimeOfProduction
                         on p.CarConfigId equals t.CarConfigId into lj
                         from res in lj.DefaultIfEmpty()
                         select new
                         {
                             CarConfigId = p.CarConfigId,
                             TimeOfProductionId = res.TimeOfProductionId,
                             TimeOfProduction = res.Time,
                             StartDate = p.Date
                         }).ToList();

            var tempList = production.ToList();

            var index = 0;

            ArrayList progress = new ArrayList();

            foreach(var item in lista)
            {
                DateTime startDate = item.StartDate;
                DateTime endDate = item.StartDate.AddMinutes(item.TimeOfProduction);
                DateTime currentDate = DateTime.Now;

                double totalMinuts = endDate.Subtract(startDate).TotalMinutes;
                double currentMinuts = currentDate.Subtract(startDate).TotalMinutes;

                double percentagemCompleta = currentMinuts / totalMinuts;

                percentagemCompleta = percentagemCompleta * 100;

                progress.Add(percentagemCompleta);

                if(percentagemCompleta >= 100 && !AlreadyInStockFinal(tempList[index].ProductionId))
                {
                    var pos = await _context.LocalizationCar.
                       FirstOrDefaultAsync(m => !m.IsOccupied);

                    _context.StockFinalProduct.Add(new StockFinalProduct { ProductionId = tempList[index].ProductionId, InsertionDate = DateTime.Now, ChassiNumber = "", LocalizationCarId = pos.LocalizationCarId });
                    await _context.SaveChangesAsync();

                    pos.IsOccupied = true;

                    _context.LocalizationCar.Update(pos);
                    await _context.SaveChangesAsync();
                }
                index++;
            }


            var model = new ProductionIndexViewModel
            {

                ProductionProgress = progress,

                ProductionList = new ListViewModel<Production>
                {
                    List = await production
                    .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                CarConfigSearched = carConfig,
                QuantitySearched = quantity,
                CarConfigs = _context.CarConfig
            };

            return View(model);
        }
        // GET: Productions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Production == null)
            {
                return NotFound();
            }

            var production = await _context.Production
                .Include(p => p.CarConfig)
                .FirstOrDefaultAsync(m => m.ProductionId == id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        // GET: Productions/Create
        public IActionResult Create()
        {
            ViewData["CarConfigId"] = new SelectList(_context.CarConfig, "CarConfigId", "ConfigName");
            return View();
        }

        // POST: Productions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductionId,Date,CarConfigId,Quantity")] Production production)
        {
            if (ModelState.IsValid)
            {
                _context.Add(production);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarConfigId"] = new SelectList(_context.CarConfig, "CarConfigId", "ConfigName", production.CarConfigId);
            return View(production);
        }

        // GET: Productions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Production == null)
            {
                return NotFound();
            }

            var production = await _context.Production.FindAsync(id);
            if (production == null)
            {
                return NotFound();
            }
            ViewData["CarConfigId"] = new SelectList(_context.CarConfig, "CarConfigId", "ConfigName", production.CarConfigId);
            return View(production);
        }

        // POST: Productions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductionId,Date,CarConfigId,Quantity")] Production production)
        {
            if (id != production.ProductionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(production);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionExists(production.ProductionId))
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
            ViewData["CarConfigId"] = new SelectList(_context.CarConfig, "CarConfigId", "ConfigName", production.CarConfigId);
            return View(production);
        }

        // GET: Productions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Production == null)
            {
                return NotFound();
            }

            var production = await _context.Production
                .Include(p => p.CarConfig)
                .FirstOrDefaultAsync(m => m.ProductionId == id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        // POST: Productions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Production == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Production'  is null.");
            }
            var production = await _context.Production.FindAsync(id);
            if (production != null)
            {
                _context.Production.Remove(production);
                await _context.SaveChangesAsync();

                var stockFinal = await _context.StockFinalProduct.FirstOrDefaultAsync(e => e.ProductionId == id);
                _context.StockFinalProduct.Remove(stockFinal);

                var pos = await _context.LocalizationCar.
                       FirstOrDefaultAsync(m => m.LocalizationCarId == stockFinal.LocalizationCarId);

                pos.IsOccupied = false;

                _context.LocalizationCar.Update(pos);
                await _context.SaveChangesAsync();
            }

            return View("ProductionDeleted");
        }

        private bool ProductionExists(int id)
        {
          return _context.Production.Any(e => e.ProductionId == id);
        }

        private bool AlreadyInStockFinal(int id)
        {
            return _context.StockFinalProduct.Any(e => e.ProductionId == id);
        }
    }
}
