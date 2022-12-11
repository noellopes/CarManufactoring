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
    public class CustomerContactsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public CustomerContactsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: CustomerContacts
        public async Task<IActionResult> Index()
        {
              return View(await _context.CustomerContact.ToListAsync());
        }

        // GET: CustomerContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CustomerContact == null)
            {
                return NotFound();
            }

            var customerContact = await _context.CustomerContact
                .FirstOrDefaultAsync(m => m.CustomerContactId == id);
            if (customerContact == null)
            {
                return NotFound();
            }

            return View(customerContact);
        }

        // GET: CustomerContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerContactId,CustomerName,CustomerRole,CustomerPhone,CustomerEmail")] CustomerContact customerContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerContact);
        }

        // GET: CustomerContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CustomerContact == null)
            {
                return NotFound();
            }

            var customerContact = await _context.CustomerContact.FindAsync(id);
            if (customerContact == null)
            {
                return NotFound();
            }
            return View(customerContact);
        }

        // POST: CustomerContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerContactId,CustomerName,CustomerRole,CustomerPhone,CustomerEmail")] CustomerContact customerContact)
        {
            if (id != customerContact.CustomerContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerContactExists(customerContact.CustomerContactId))
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
            return View(customerContact);
        }

        // GET: CustomerContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CustomerContact == null)
            {
                return NotFound();
            }

            var customerContact = await _context.CustomerContact
                .FirstOrDefaultAsync(m => m.CustomerContactId == id);
            if (customerContact == null)
            {
                return NotFound();
            }

            return View(customerContact);
        }

        // POST: CustomerContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CustomerContact == null)
            {
                return Problem("Entity set 'CarManufactoringContext.CustomerContact'  is null.");
            }
            var customerContact = await _context.CustomerContact.FindAsync(id);
            if (customerContact != null)
            {
                _context.CustomerContact.Remove(customerContact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerContactExists(int id)
        {
          return _context.CustomerContact.Any(e => e.CustomerContactId == id);
        }
    }
}
