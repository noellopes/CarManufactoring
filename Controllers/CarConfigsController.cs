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
    public class CarConfigsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public CarConfigsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: CarConfigs
        [AllowAnonymous]
        public async Task<IActionResult> Index(string configName = null, int numExtras = 0, double addedPrice = 0, double finalPrice = 0,string car = null, string brand = null,  int page = 1)
        {
            var carconfigs = _context.CarConfig.Include(c => c.Car).Include(c => c.Car.Brand)
                 .Where(c => configName == null || c.ConfigName.Contains(configName))
                 .Where(c => numExtras == 0 || c.NumExtras.Equals(numExtras))
                 .Where(c => addedPrice == 0 || c.AddedPrice.Equals(addedPrice))
                 .Where(c => car == null || c.Car.CarModel.Contains(car))
                 .Where(c => finalPrice == 0 || c.FinalPrice.Equals(finalPrice))
                 .Where(c => brand == null || c.Car.Brand.BrandName.Contains(brand))
                 .OrderBy(c => c.AddedPrice);

            var pagingInfo = new PagingInfoViewModel(await carconfigs.CountAsync(), page);

            var model = new CarConfigIndexViewModel
            {
                CarConfigsList = new ListViewModel<CarConfig>
                {
                    List = await carconfigs
                    .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                ConfigNameSearched = configName,
                NumExtrasSearched = numExtras,
                AddedPriceSearched = addedPrice,
                FinalPriceSearched = finalPrice,
                BrandSearched = brand,
                CarSearched = car,
            };

                 return View(model);
        }

        // GET: CarConfigs/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarConfig == null)
            {
                return NotFound();
            }

            var carConfig = await _context.CarConfig
                .Include(c => c.Car).Include(c => c.Car.Brand)
                .FirstOrDefaultAsync(m => m.CarConfigId == id);
            if (carConfig == null)
            {
                return View("CarConfigNotFound");
            }
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(carConfig);
        }

        // GET: CarConfigs/Create
        [Authorize(Roles ="Colaborator")]
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarModel");
            return View();
        }

        // POST: CarConfigs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Colaborator")]
        public async Task<IActionResult> Create([Bind("CarConfigId,ConfigName,NumExtras,AddedPrice,FinalPrice,CarId")] CarConfig carConfig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carConfig);
                await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Car Config created successfully.";

                return RedirectToAction(nameof(Details), new { id = carConfig.CarConfigId });
            }
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarModel", carConfig.CarId);
            return View(carConfig);
        }

        // GET: CarConfigs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarConfig == null)
            {
                return NotFound();
            }

            var carConfig = await _context.CarConfig.FindAsync(id);
            if (carConfig == null)
            {
                return View("CarConfigNotFound");
            }
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarModel", carConfig.CarId);
            return View(carConfig);
        }

        // POST: CarConfigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarConfigId,ConfigName,NumExtras,AddedPrice,FinalPrice,CarId")] CarConfig carConfig)
        {
            if (id != carConfig.CarConfigId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carConfig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarConfigExists(carConfig.CarConfigId))
                    {
                        return View("CarConfigNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarModel", carConfig.CarId);
            return View(carConfig);
        }

        // GET: CarConfigs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarConfig == null)
            {
                return NotFound();
            }

            var carConfig = await _context.CarConfig
                .Include(c => c.Car).Include(c => c.Car.Brand)
                .FirstOrDefaultAsync(m => m.CarConfigId == id);
            if (carConfig == null)
            {
                return View("CarConfigNotFound");
            }
            ViewBag.Error = "Are you sure you want to delete this car configuration?";
            ViewBag.NumberCarConfSalesLines = await _context.SalesLine.Where(b => b.CarConfigId == id).CountAsync();
            return View(carConfig);
        }

        // POST: CarConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarConfig == null)
            {
                return Problem("Entity set 'CarManufactoringContext.CarConfig'  is null.");
            }
            var carConfig = await _context.CarConfig.FindAsync(id);
            if (carConfig != null)
            {
            _context.CarConfig.Remove(carConfig);
            await _context.SaveChangesAsync();
            }
            TempData["SuccessMessage"] = "Car removed successfully.";
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View("CarConfigDeleted");
        }

        private bool CarConfigExists(int id)
        {
          return _context.CarConfig.Any(e => e.CarConfigId == id);
        }
    }
}
