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
using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Authorization;

namespace CarManufactoring.Controllers
{
    //[Authorize]
    public class OrdersController : Controller
    {
        private readonly CarManufactoringContext _context;

        public OrdersController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Orders
        [AllowAnonymous]
        public async Task<IActionResult> Index(DateTime OrderDate = default, string OrderState = null, DateTime StateDate = default, string Customer = null, int page = 1)
        {

            var orders = _context.Order.Include(c => c.Customer).Include(c => c.OrderState)
                .Where(c => OrderDate == default || c.OrderDate.Equals(OrderDate))
                .Where(c => OrderState == null || c.OrderState.OrderStateName.Contains(OrderState))
                .Where(c => StateDate == default || c.StateDate.Equals(StateDate))
                .Where(c => Customer == null || c.Customer.CustomerName.Contains(Customer))
                .OrderBy(c => c.OrderDate);
            var pagingInfo = new PagingInfoViewModel(await orders.CountAsync(), page);

            var model = new OrderIndexViewModel
            {
                OrderList = new ListViewModel<Order>
                {
                    List = await orders
                    .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                OrderDateSearched = OrderDate,
                OrderStateSearched = OrderState,
                StateDateSearched = StateDate,
                CustomerSearched = Customer,

            };
            return View(model);
        }


        // GET: Orders/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.OrderState)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return View("OrderNotFound");
            }
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(order);
        }

        // GET: Orders/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            Order obj = new();
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName");
            ViewData["OrderStateId"] = new SelectList(_context.OrderState, "OrderStateId", "OrderStateName");
            return View(obj);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("OrderId,OrderDate,OrderStateId,StateDate,CustomerId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Order created successfully.";
                return RedirectToAction(nameof(Details), new { id = order.OrderId });

            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName", order.CustomerId);
            ViewData["OrderStateId"] = new SelectList(_context.OrderState, "OrderStateId", "OrderStateName", order.OrderStateId);
            return View(order);
        }

        // GET: Orders/Edit/5
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return View("OrderNotFound");
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName", order.CustomerId);
            ViewData["OrderStateId"] = new SelectList(_context.OrderState, "OrderStateId", "OrderStateName", order.OrderStateId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderDate,OrderStateId,StateDate,CustomerId")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return View("OrderNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName", order.CustomerId);
            ViewData["OrderStateId"] = new SelectList(_context.OrderState, "OrderStateId", "OrderStateName", order.OrderStateId);
            return View(order);
        }

        // GET: Orders/Delete/5
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.OrderState)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return View("OrderNotFound");
            }
            TempData["SuccessMessage"] = " ";
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Order == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Order'  is null.");
            }
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }

            _context.Order.Remove(order);
            TempData["SuccessMessage"] = "Order removed successfully.";
            await _context.SaveChangesAsync();
            return View("OrderDeleted");
        }

        private bool OrderExists(int id)
        {
          return _context.Order.Any(e => e.OrderId == id);
        }
    }
}
