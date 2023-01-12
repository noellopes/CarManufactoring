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
    public class StockFinalProductsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public StockFinalProductsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: StockFinalProducts
        public async Task<IActionResult> Index(string Line=null, string Row = null,string CarConfig= null, string ChassiNumber = null, DateTime InsertionDate = default,int page =1)
       
        {
            var number   = _context.StockFinalProduct.Count();
            if (number == 0)
            {
                return View("NoDataFound");
            }
            var stockFinalProduction = _context.StockFinalProduct.Include(s => s.LocalizationCar).Include(s => s.Production)
                .Where(c => Line == null || c.LocalizationCar.Line == Line)
                .Where(c => Row == null || c.LocalizationCar.Row == Row)
                .Where(c => CarConfig == null || c.Production.CarConfig.ConfigName.Equals(CarConfig))
                .Where(c => ChassiNumber == null || c.ChassiNumber.Equals(ChassiNumber))
                .Where(c => InsertionDate == default || c.InsertionDate == InsertionDate)
                .OrderBy(c => c.LocalizationCar.Line);
          
            var PagingInfoVar = new PagingInfoViewModel(await stockFinalProduction.CountAsync(), page);

            PagingInfoVar.PageSize = 10;
            PagingInfoVar.Pages_Show_Before_After = 6;

            try
            {
                var model = new StockFinalProductIndexViewModel
                {
                    StockFinalProductList = new ListViewModel<StockFinalProduct>
                    {
                        List = await stockFinalProduction
                    .Skip((PagingInfoVar.CurrentPage - 1) * PagingInfoVar.PageSize)
                    .Take(PagingInfoVar.PageSize).ToListAsync(),
                        PagingInfo = PagingInfoVar
                    },
                    LineSearched = Line,
                    CarConfigNameSearched = CarConfig,
                    RowSearched = Row,
                    ChassiNumberSearched = ChassiNumber,
                    InsertionDateSearched = InsertionDate,
                    LocalizationCar = _context.LocalizationCar.OrderBy(c => c.Line).ToList(),
                    CarConfigs = _context.CarConfig.OrderBy(c => c.ConfigName).ToList()

                };

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Not Found";
               return await Index( Line,  Row,  CarConfig,  ChassiNumber,  InsertionDate, page );
            }

        }

        // GET: StockFinalProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StockFinalProduct == null)
            {
                return NotFound();
            }

            var stockFinalProduct = await _context.StockFinalProduct
                .Include(s => s.LocalizationCar)
                .Include(s => s.Production)
                .FirstOrDefaultAsync(m => m.StockFinalProductId == id);
            if (stockFinalProduct == null)
            {
                return NotFound();
            }

            return View(stockFinalProduct);
        }

        // GET: StockFinalProducts/Create
        public IActionResult Create()
        {
            ViewData["LocalizationCarId"] = new SelectList(_context.LocalizationCar, "LocalizationCarId", "Line");
            ViewData["ProductionId"] = new SelectList(_context.Production, "ProductionId", "ProductionId");
            return View();
        }

        // POST: StockFinalProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockFinalProductId,LocalizationCarId,ChassiNumber,ProductionId")] StockFinalProduct stockFinalProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockFinalProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalizationCarId"] = new SelectList(_context.LocalizationCar, "LocalizationCarId", "Line", stockFinalProduct.LocalizationCarId);
            ViewData["ProductionId"] = new SelectList(_context.Production, "ProductionId", "ProductionId", stockFinalProduct.ProductionId);
            return View(stockFinalProduct);
        }

        // GET: StockFinalProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StockFinalProduct == null)
            {
                return NotFound();
            }

            var stockFinalProduct = await _context.StockFinalProduct.FindAsync(id);
            if (stockFinalProduct == null)
            {
                return NotFound();
            }
            ViewData["LocalizationCarId"] = new SelectList(_context.LocalizationCar, "LocalizationCarId", "Line", stockFinalProduct.LocalizationCarId);
            ViewData["ProductionId"] = new SelectList(_context.Production, "ProductionId", "ProductionId", stockFinalProduct.ProductionId);
            return View(stockFinalProduct);
        }

        // POST: StockFinalProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockFinalProductId,LocalizationCarId,ChassiNumber,ProductionId")] StockFinalProduct stockFinalProduct)
        {
            if (id != stockFinalProduct.StockFinalProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockFinalProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockFinalProductExists(stockFinalProduct.StockFinalProductId))
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
            ViewData["LocalizationCarId"] = new SelectList(_context.LocalizationCar, "LocalizationCarId", "Line", stockFinalProduct.LocalizationCarId);
            ViewData["ProductionId"] = new SelectList(_context.Production, "ProductionId", "ProductionId", stockFinalProduct.ProductionId);
            return View(stockFinalProduct);
        }

        // GET: StockFinalProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StockFinalProduct == null)
            {
                return NotFound();
            }

            var stockFinalProduct = await _context.StockFinalProduct
                .Include(s => s.LocalizationCar)
                .Include(s => s.Production)
                .FirstOrDefaultAsync(m => m.StockFinalProductId == id);
            if (stockFinalProduct == null)
            {
                return NotFound();
            }

            return View(stockFinalProduct);
        }

        // POST: StockFinalProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StockFinalProduct == null)
            {
                return Problem("Entity set 'CarManufactoringContext.StockFinalProduct'  is null.");
            }
            var stockFinalProduct = await _context.StockFinalProduct.FindAsync(id);
            if (stockFinalProduct != null)
            {
                _context.StockFinalProduct.Remove(stockFinalProduct);
                await _context.SaveChangesAsync();

                var pos = await _context.LocalizationCar.
                       FirstOrDefaultAsync(m => m.LocalizationCarId == stockFinalProduct.LocalizationCarId);

                pos.IsOccupied = false;

                _context.LocalizationCar.Update(pos);
                await _context.SaveChangesAsync();

            }

            return View("StockFinalProductDeleted");
        }

        private bool StockFinalProductExists(int id)
        {
          return _context.StockFinalProduct.Any(e => e.StockFinalProductId == id);
        }
    }
}
