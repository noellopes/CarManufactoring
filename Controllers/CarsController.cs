using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using CarManufactoring.ViewModels;

namespace CarManufactoring.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public CarsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index(string carModel = null, int launchYear = 0, double price = 0, string brand = null, int timeProduction = 0, int page = 1 )
        {

            var cars = _context.Car.Include(c => c.Brand)
                .Where(c => carModel == null || c .CarModel.Contains(carModel))
                .Where(c => launchYear == 0 || c.LaunchYear.Equals(launchYear))
                .Where(c => price == 0 || c.BasePrice.Equals(price))
                .Where(c => brand == null || c.Brand.BrandName.Contains(brand))
                .Where(c => timeProduction == 0 || c.TimeProduction.Equals(timeProduction))
                .OrderBy(c => c.BasePrice);
            var pagingInfo = new PagingInfoViewModel(await cars.CountAsync(), page);

            var model = new CarIndexViewModel
            {
                CarsList = new ListViewModel<Car>
                {
                    List = await cars
                    .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                CarModelSearched = carModel,
                LaunchYearSearched =launchYear,
                PriceSearched = price,
                BrandSearched = brand,
                TimeProductionSearched = timeProduction,
            };
            return View(model);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.Brand)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            Car obj = new();
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandName");
            return View(obj);
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarId,BrandId,CarModel,LaunchYear,BasePrice,TimeProduction")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Car created successfully.";

                return RedirectToAction(nameof(Details), new { id = car.CarId });
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandName", car.BrandId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandName", car.BrandId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarId,BrandId,CarModel,LaunchYear,BasePrice,TimeProduction")] Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarId))
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
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandName", car.BrandId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.Brand)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            TempData["SuccessMessage"] = " ";
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Car == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Car'  is null.");
            }
            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                //TODO: Car was not found page 
            }
            _context.Car.Remove(car);
            TempData["SuccessMessage"] = "Car removed successfully.";
            await _context.SaveChangesAsync();
            return View("CarDeleted");
        }

        private bool CarExists(int id)
        {
          return _context.Car.Any(e => e.CarId == id);
        }
    }
}
