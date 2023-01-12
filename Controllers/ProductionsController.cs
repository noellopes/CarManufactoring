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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CarManufactoring.Controllers
{
    public class ProductionsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public ProductionsController(CarManufactoringContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin,ProdutionManager")]
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

            var salesLine = await _context.SalesLine.ToListAsync();

            var listaProducao = await production.ToListAsync();

            for(int i = listaProducao.Count-1; i >= 0; i--)
            {
                DateTime startDate = listaProducao[i].Date;
                var time = await _context.TimeOfProduction.Include(s => s.CarConfig).FirstOrDefaultAsync(c => c.CarConfigId == listaProducao[i].CarConfigId);
                DateTime endDate = listaProducao[i].Date.AddMinutes(time.Time);
                DateTime currentDate = DateTime.Now;

                double totalMinuts = endDate.Subtract(startDate).TotalMinutes;
                double currentMinuts = currentDate.Subtract(startDate).TotalMinutes;

                double percentagemCompleta = currentMinuts / totalMinuts;

                percentagemCompleta = percentagemCompleta * 100;


                var order = await _context.Order.FirstOrDefaultAsync(m => m.OrderId == salesLine[i].OrderId);

                //var orderStates = await _context.OrderState.ToListAsync();

                if(order.OrderStateId == 1)
                {
                    order.OrderStateId = 2;
                    _context.Order.Update(order);
                    await _context.SaveChangesAsync();
                }

                if (percentagemCompleta >= 100 && order.OrderStateId == 2)
                {
                    
                    order.OrderStateId = 3;
                    order.StateDate = endDate;
                    _context.Update(order);
                    await _context.SaveChangesAsync();

                    
                   
                    var pos = await _context.LocalizationCar.
                    FirstOrDefaultAsync(m => !m.IsOccupied);

                    _context.StockFinalProduct.Add(new StockFinalProduct { ProductionId = listaProducao[i].ProductionId, InsertionDate = DateTime.Now, ChassiNumber = "", LocalizationCarId = pos.LocalizationCarId });

                    pos.IsOccupied = true;

                    _context.LocalizationCar.Update(pos);
                    await _context.SaveChangesAsync();
                    
                }
                
            }


            var model = new ProductionIndexViewModel
            {

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

        [Authorize(Roles = "Admin,ProdutionManager")]
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
        [Authorize(Roles = "Admin,ProdutionManager")]
        // GET: Productions/Create
        public IActionResult Create()
        {
            ViewData["CarConfigId"] = new SelectList(_context.CarConfig, "CarConfigId", "ConfigName");
            return View();
        }
        [Authorize(Roles = "Admin,ProdutionManager")]
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
        [Authorize(Roles = "Admin,ProdutionManager")]
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
        [Authorize(Roles = "Admin,ProdutionManager")]
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
        [Authorize(Roles = "Admin,ProdutionManager")]
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
        [Authorize(Roles = "Admin,ProdutionManager")]
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
                var stockFinal = await _context.StockFinalProduct.Include(p => p.LocalizationCar).FirstOrDefaultAsync(e => e.ProductionId == id);

                _context.Production.Remove(production);

                if(stockFinal != null)
                {
                    var pos = await _context.LocalizationCar.
                       FirstOrDefaultAsync(m => m.LocalizationCarId == stockFinal.LocalizationCarId);

                    pos.IsOccupied = false;

                    _context.LocalizationCar.Update(pos);
                }

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
