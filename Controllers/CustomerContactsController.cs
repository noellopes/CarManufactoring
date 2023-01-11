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
using Microsoft.AspNetCore.Authorization;

namespace CarManufactoring.Controllers
{
    [Authorize]
    public class CustomerContactsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public CustomerContactsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: CustomerContacts
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Index(string CustomerName = null, string CustomerRole = null, string CustomerPhone = null, string CustomerEmail = null, string Customer = null, int page = 1)
        {

            var contacts = _context.CustomerContact.Include(c => c.Customer)
                .Where(c => CustomerName == null || c.CustomerName.Equals(CustomerName))
                .Where(c => CustomerRole == null || c.CustomerRole.Contains(CustomerRole))
                .Where(c => CustomerPhone == null || c.CustomerPhone.Equals(CustomerPhone))
                .Where(c => CustomerEmail == null || c.CustomerEmail.Equals(CustomerEmail))
                .Where(c => Customer == null || c.Customer.CustomerName.Contains(Customer))
                .OrderBy(c => c.CustomerName);
            var pagingInfo = new PagingInfoViewModel(await contacts.CountAsync(), page);

            var model = new CustomerContactsIndexViewModel
            {
                CustomerContactList = new ListViewModel<CustomerContact>
                {
                    List = await contacts
                    .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                CustomerContactNameSearched = CustomerName,
                CustomerRoleSearched = CustomerRole,
                CustomerPhoneSearched = CustomerPhone,
                CustomerEmailSearched = CustomerEmail,
                CustomerSearched = Customer,

            };
            return View(model);
        }


        // GET: CustomerContacts/Details/5
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CustomerContact == null)
            {
                return NotFound();
            }

            var customerContact = await _context.CustomerContact
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.CustomerContactId == id);
            if (customerContact == null)
            {
                return View("CustomerContactsNotFound");
            }
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(customerContact);
        }

        // GET: CustomerContacts/Create
        [Authorize(Roles = "Colaborator")]
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName");
            return View();
        }

        // POST: CustomerContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Create([Bind("CustomerContactId,CustomerName,CustomerRole,CustomerPhone,CustomerEmail,CustomerId")] CustomerContact customerContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerContact);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Customer Contact created successfully.";
                return RedirectToAction(nameof(Details), new { id = customerContact.CustomerContactId });
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName", customerContact.CustomerId);
            return View(customerContact);
        }

        // GET: CustomerContacts/Edit/5
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CustomerContact == null)
            {
                return NotFound();
            }

            var customerContact = await _context.CustomerContact.FindAsync(id);
            if (customerContact == null)
            {
                return View("CustomerContactsNotFound");
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName", customerContact.CustomerId);
            return View(customerContact);
        }

        // POST: CustomerContacts/Edit/5
        [Authorize(Roles = "Colaborator")]
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerContactId,CustomerName,CustomerRole,CustomerPhone,CustomerEmail,CustomerId")] CustomerContact customerContact)
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
                        return View("CustomerContactsNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName", customerContact.CustomerId);
            return View(customerContact);
        }

        // GET: CustomerContacts/Delete/5
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CustomerContact == null)
            {
                return NotFound();
            }

            var customerContact = await _context.CustomerContact
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.CustomerContactId == id);
            if (customerContact == null)
            {
                return View("CustomerContactsNotFound");
            }

            return View(customerContact);
        }

        // POST: CustomerContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Colaborator")]
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

            _context.CustomerContact.Remove(customerContact);
            TempData["SuccessMessage"] = "Customer Contact removed successfully.";
            await _context.SaveChangesAsync();
            return View("CustomerContactDeleted");
        }

        private bool CustomerContactExists(int id)
        {
          return _context.CustomerContact.Any(e => e.CustomerContactId == id);
        }
    }
}
