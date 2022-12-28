﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using CarManufactoring.ViewModels;

namespace CarManufactoring.Controllers
{
    public class SalesLinesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public SalesLinesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: SalesLines
        public async Task<IActionResult> Index(int quantity = 0, double price = 0, DateTime deliveryDate = default, string order = null, string carconfig = null, int page = 1)
        {
            
            var salesLine = _context.SalesLine.Include(s => s.CarConfig).Include(s => s.Order)
                .Where(c => quantity == 0 || c.Quantity.Equals(quantity))
                .Where(c => price == 0 || c.Price.Equals(price))
                .Where(c => deliveryDate == default || c.DeliveryDate.Equals(deliveryDate))
                .Where(c => order == null || c.Order.Customer.CustomerName.Contains(order))
                .Where(c => carconfig == null || c.CarConfig.ConfigName.Contains(carconfig))
                .OrderBy(c => c.Quantity);
            var pagingInfo = new PagingInfoViewModel(await salesLine.CountAsync(), page);

            var model = new SalesLineIndexViewModel
            {
                SalesLineList = new ListViewModel<SalesLine>
                {
                    List = await salesLine
                    .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                QuantitySearched = quantity,
                PriceSearched = price,
                DeliveryDateSearched = deliveryDate,
                OrderSearched = order,
                CarConfigSearched = carconfig,
            };
            return View(model);
        }

        // GET: SalesLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalesLine == null)
            {
                return NotFound();
            }

            var salesLine = await _context.SalesLine
                .Include(s => s.CarConfig)
                .Include(s => s.Order)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (salesLine == null)
            {
                return NotFound();
            }

            return View(salesLine);
        }

        // GET: SalesLines/Create
        public IActionResult Create()
        {
            ViewData["CarConfigId"] = new SelectList(_context.CarConfig, "CarConfigId", "ConfigName");
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId");
            return View();
        }

        // POST: SalesLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CarConfigId,Quantity,DeliveryDate,Price")] SalesLine salesLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarConfigId"] = new SelectList(_context.CarConfig, "CarConfigId", "ConfigName", salesLine.CarConfigId);
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", salesLine.OrderId);
            return View(salesLine);
        }

        // GET: SalesLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SalesLine == null)
            {
                return NotFound();
            }

            var salesLine = await _context.SalesLine.FindAsync(id);
            if (salesLine == null)
            {
                return NotFound();
            }
            ViewData["CarConfigId"] = new SelectList(_context.CarConfig, "CarConfigId", "ConfigName", salesLine.CarConfigId);
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", salesLine.OrderId);
            return View(salesLine);
        }

        // POST: SalesLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CarConfigId,Quantity,DeliveryDate,Price")] SalesLine salesLine)
        {
            if (id != salesLine.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesLineExists(salesLine.OrderId))
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
            ViewData["CarConfigId"] = new SelectList(_context.CarConfig, "CarConfigId", "ConfigName", salesLine.CarConfigId);
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", salesLine.OrderId);
            return View(salesLine);
        }

        // GET: SalesLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SalesLine == null)
            {
                return NotFound();
            }

            var salesLine = await _context.SalesLine
                .Include(s => s.CarConfig)
                .Include(s => s.Order)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (salesLine == null)
            {
                return NotFound();
            }

            return View(salesLine);
        }

        // POST: SalesLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SalesLine == null)
            {
                return Problem("Entity set 'CarManufactoringContext.SalesLine'  is null.");
            }
            var salesLine = await _context.SalesLine.FindAsync(id);
            if (salesLine != null)
            {
                _context.SalesLine.Remove(salesLine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesLineExists(int id)
        {
          return _context.SalesLine.Any(e => e.OrderId == id);
        }
    }
}