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
    public class CustomersController : Controller
    {
        private readonly CarManufactoringContext _context;
        //private readonly UserManager<IdentityUser> _userManager;

        public CustomersController(CarManufactoringContext context /*, UserManager<IdentityUser> userManager*/)
        {
            _context = context;
            //_userManager = userManager
        }

        // GET: Customers
        public async Task<IActionResult> Index(string CustomerName = null, DateTime CustomerFoundDate = default, int page = 1)
        {

            var customers = _context.Customer
                .Where(c => CustomerName == null || c.CustomerName.Equals(CustomerName))
                .Where(c => CustomerFoundDate == default || c.CustomerFoundDate.Equals(CustomerFoundDate))
                .OrderBy(c => c.CustomerFoundDate);
            var pagingInfo = new PagingInfoViewModel(await customers.CountAsync(), page);

            var model = new CustomerIndexViewModel
            {
                CustomerList = new ListViewModel<Customer>
                {
                    List = await customers
                    .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                CustomerNameSearched = CustomerName,
                CustomerFoundDateSearched = CustomerFoundDate,

            };
            return View(model);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[AllowAnonymous]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,CustomerFoundDate")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                /*
                var user = await _userManager.FindByNameAsync(customerInfo.Email);
                if (user != null) {
                    ModelState.AddModelError("Email", "An user with that email already exists. Did you forgot the password?");
                    return View();
                }

                user = new IdentityUser(customerInfo.Email);
                var result = await _userManager.CreateAsync(user, customerInfo.Password);

                if (!result.Succeeded) {
                    ModelState.AddModelError("", "Something went wrong. Please try again later.");
                    return View();
                }

                result = await _userManager.AddToRoleAsync(user, "Customer");
                if(!result.Succeeded) {
                    ModelState.AddModelError("", "Something went wrong. Please try again later.");
                    return View();
                }

                var customer = new Customer {
                    Name = customerInfo.Name,
                    Email = customerInfo.Email,
                };
                _context.Add(customer);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
                 */

                _context.Add(customer);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Customer created successfully.";
                return RedirectToAction(nameof(Details), new { id = customer.CustomerId });
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerName,CustomerFoundDate")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Customer'  is null.");
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer != null)
            {
                _context.Customer.Remove(customer);
            }


            _context.Customer.Remove(customer);
            TempData["SuccessMessage"] = "Customer removed successfully.";
            await _context.SaveChangesAsync();
            return View("CustomerDeleted");
        }

        private bool CustomerExists(int id)
        {
          return _context.Customer.Any(e => e.CustomerId == id);
        }
    }
}
