using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using CarManufactoring.ViewModels.Group2;
using CarManufactoring.ViewModels;

namespace CarManufactoring.Controllers
{
    public class CarPartsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public CarPartsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: CarParts
        public async Task<IActionResult> Index(string name = null, string reference = null, string partType = null, string brand = null, string cmodel = null,int page = 1) {
            //var CarParts = CarPartsList.CarPart.OrderBy(cp => cp.Name);
           
            var CarParts = Product.SearchProd(_context, name, partType, reference, brand, cmodel);

            var pagingInfo = new PagingInfoViewModel(await CarParts.CountAsync(), page);

            var model = new CarPartsIndexViewModel {

                CarPartsList = new ListViewModel<CarParts> {

                    List = await CarParts
                    .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize) 
                    .Take(pagingInfo.PageSize)
                    .ToListAsync(),
                    PagingInfo = pagingInfo
                },
                NameSearch = name,
                ReferenceSearch = reference,
                TypeSearch = partType,
                BrandSearch = brand,
                ModelSearch = cmodel
            };

            return View(model);
        }

        // GET: CarParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarParts == null)
            {
                return NotFound();
            }

            var carParts = await _context.CarParts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (carParts == null)
            {
                return NotFound();
            }

            ViewBag.SuccessMessage = TempData["SuccessMessage"];

            return View(carParts);
        }

        // GET: CarParts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartType,ProductId,Reference,Name,PointOfPurchase,SafetyStock,LevelService")] CarParts carParts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carParts);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Car Part Added Successfully.";

                return RedirectToAction(nameof(Details), new { id = carParts.ProductId});
            }

            return View(carParts);
        }

        // GET: CarParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarParts == null)
            {
                return NotFound();
            }

            var carParts = await _context.CarParts.FindAsync(id);
            if (carParts == null)
            {
                return View("CarPartsNotFound");
            }
            return View(carParts);
        }

        // POST: CarParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartType,ProductId,Reference,Name,PointOfPurchase,SafetyStock,LevelService")] CarParts carParts){
            if (id != carParts.ProductId) {
                return NotFound();
            }

            if (ModelState.IsValid){
                try {
                    _context.Update(carParts);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Changes saved sucessfully.";

                    return RedirectToAction(nameof(Details), new { id = carParts.ProductId });
                }
                catch (DbUpdateConcurrencyException){
                    if (!CarPartsExists(carParts.ProductId)){
                        return View("CarPartNotFound");
                    }
                    else{
                        throw;
                    }
                }
            }
            return View(carParts);
        }

        // GET: CarParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarParts == null)
            {
                return View("CarPartNotFound");
            }

            var carParts = await _context.CarParts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (carParts == null)
            {
                return View("CarPartNotFound");
            }

            return View(carParts);
        }

        // POST: CarParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarParts == null)
            {
                return Problem("Entity set 'CarManufactoringContext.CarParts'  is null.");
            }
            var carParts = await _context.CarParts.FindAsync(id);
            if (carParts != null)
            {
                _context.CarParts.Remove(carParts);
                await _context.SaveChangesAsync();
            }
            
           
            return View("_CarPartDeleted");
        }

        private bool CarPartsExists(int id)
        {
          return _context.CarParts.Any(e => e.ProductId == id);
        }
    }
}
