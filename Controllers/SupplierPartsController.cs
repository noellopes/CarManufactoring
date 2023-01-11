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

using CarManufactoring.ViewModels.Group2;
using Microsoft.AspNetCore.Authorization;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.AspNetCore.Identity;

namespace CarManufactoring.Controllers
{
    public class SupplierPartsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public SupplierPartsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: SupplierParts
        int CurrentPageSize = 5;
        public async Task<IActionResult> Index(string name = null ,string country= null, string email = null ,int page = 1, int pagesize = -1)
        {
            if (pagesize != -1)
            {
                CurrentPageSize = pagesize;
            }
            var supplierparts = _context.SupplierParts
              .Where(b => name == null || b.Name.Contains(name))
              .Where(b => country == null || b.Country.Contains(country))
              .Where(b => email == null || b.Email.Contains(email))
              .OrderBy(b => b.Name);

            var pagingInfo = new PagingInfoViewModel(await supplierparts.CountAsync(), page, CurrentPageSize);

            try
            {
                
                var model = new SupplierPartsIndexViewModel
                {
                    SupplierPartsList = new ListViewModel<SupplierParts>
                    {
                    List = await supplierparts
                        .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                        .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },

                NameSearch = name,
                CountrySearch = country,
                EmailSearch = email

            };

                return View(model);

            }
            catch (Exception ex)
            {
                return await Index(null, null, null ,page, CurrentPageSize);
            }

        }

        // GET: SupplierParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SupplierParts == null)
            {
                return NotFound();
            }

            var supplierParts = await _context.SupplierParts
                .FirstOrDefaultAsync(m => m.SupplierPartsId == id);
            if (supplierParts == null)
            {
                return NotFound();
            }
            ViewBag.SuccessMessageSuppliersParts = TempData["SuccessMessageSuppliersParts"];

            return View(supplierParts);
        }


        // GET: SupplierParts/Create
        public IActionResult Create()
        {
            return View();
        }


        //[Authorize(Roles = "Supplier")]


        // POST: SupplierParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierPartsId,Logo,Name,Email,Contact,ZipCode,Address,Country")] SupplierParts supplierParts)
        {
            if (ModelState.IsValid)
            {
                string[] PaisNum = supplierParts.Country.Split(' ');
                supplierParts.Country = PaisNum[0];
                supplierParts.Contact = PaisNum[1] + " " + supplierParts.Contact;
                _context.Add(supplierParts);
                await _context.SaveChangesAsync();

                //Adicionar Produtos ao novo Fornecedor
                Random rnd = new Random();
                int dias;
                int disp;
                foreach (CarParts cp in _context.CarParts.ToArray()) {
                    dias = rnd.Next(1, 31);
                    disp = rnd.Next(0, 2);
                    _context.SupplierPartsCarParts.AddRange(
                        new SupplierPartsCarParts { ProductId = cp.ProductId, SupplierPartsId = supplierParts.SupplierPartsId, PrazoEntrega = dias, Disponibilidade = Convert.ToBoolean(disp) }
                    );
                    Console.WriteLine(cp.ProductId);
                }
                await _context.SaveChangesAsync();
                //Adicionados todos os produtos existentes ao fornecedor criado

                TempData["SuccessMessageSuppliersParts"] = "Created " + supplierParts.Name + " Successfully!";
                return RedirectToAction(nameof(Details), new { id = supplierParts.SupplierPartsId });
            }
            return View(supplierParts);
        }

        // GET: SupplierParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SupplierParts == null)
            {
                return NotFound();
            }

            var supplierParts = await _context.SupplierParts.FindAsync(id);
            if (supplierParts == null)
            {
                return NotFound();
            }
            return View(supplierParts);
        }

        
        //[Authorize(Roles = "Supplier")]
        
        
        // POST: SupplierParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierPartsId,Logo,Name,Email,Contact,ZipCode,Address,Country")] SupplierParts supplierParts)
        {
            if (id != supplierParts.SupplierPartsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierParts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierPartsExists(supplierParts.SupplierPartsId))
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
            return View(supplierParts);
        }

        // GET: SupplierParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SupplierParts == null)
            {
                return NotFound();
            }

            var supplierParts = await _context.SupplierParts
                .FirstOrDefaultAsync(m => m.SupplierPartsId == id);
            if (supplierParts == null)
            {
                return NotFound();
            }

            return View(supplierParts);
        }

        //[Authorize(Roles = "Supplier")]
        
        
        // POST: SupplierParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SupplierParts == null)
            {
                return Problem("Entity set 'CarManufactoringContext.SupplierParts'  is null.");
            }
            var supplierParts = await _context.SupplierParts.FindAsync(id);
            if (supplierParts != null)
            {
                try
                {
                    _context.SupplierParts.Remove(supplierParts);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    return View("SupplierPartCascade");
                }
            }

            return View("SupplierPartDeleted");
        }

        private bool SupplierPartsExists(int id)
        {
          return _context.SupplierParts.Any(e => e.SupplierPartsId == id);
        }
    }
}
