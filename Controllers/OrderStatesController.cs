using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarManufactoring.Controllers
{
    [Authorize]
    public class OrderStatesController : Controller
    {
        private readonly CarManufactoringContext _context;

        public OrderStatesController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: OrderStates
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.OrderState.ToListAsync());
        }

        // GET: OrderStates/Details/5
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderState == null)
            {
                return NotFound();
            }

            var orderState = await _context.OrderState
                .FirstOrDefaultAsync(m => m.OrderStateId == id);
            if (orderState == null)
            {
                return NotFound();
            }

            return View(orderState);
        }

        // GET: OrderStates/Create
        [Authorize(Roles = "Colaborator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Create([Bind("OrderStateId,OrderStateName")] OrderState orderState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderState);
        }

        // GET: OrderStates/Edit/5
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderState == null)
            {
                return NotFound();
            }

            var orderState = await _context.OrderState.FindAsync(id);
            if (orderState == null)
            {
                return NotFound();
            }
            return View(orderState);
        }

        // POST: OrderStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Edit(int id, [Bind("OrderStateId,OrderStateName")] OrderState orderState)
        {
            if (id != orderState.OrderStateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderStateExists(orderState.OrderStateId))
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
            return View(orderState);
        }

        // GET: OrderStates/Delete/5
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderState == null)
            {
                return NotFound();
            }

            var orderState = await _context.OrderState
                .FirstOrDefaultAsync(m => m.OrderStateId == id);
            if (orderState == null)
            {
                return NotFound();
            }

            return View(orderState);
        }

        // POST: OrderStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderState == null)
            {
                return Problem("Entity set 'CarManufactoringContext.OrderState'  is null.");
            }
            var orderState = await _context.OrderState.FindAsync(id);
            if (orderState != null)
            {
                _context.OrderState.Remove(orderState);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderStateExists(int id)
        {
          return _context.OrderState.Any(e => e.OrderStateId == id);
        }
    }
}
