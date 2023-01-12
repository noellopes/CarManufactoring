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
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Authorization;

namespace CarManufactoring.Controllers
{
    [Authorize]
    public class ExtrasController : Controller
    {
        private readonly CarManufactoringContext _context;

        public ExtrasController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Extras
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Index(string descExtra = null, double price = 0, int page = 1)
        {
            var extras = _context.Extra
              .Where(m => descExtra == null || m.DescExtra.Contains(descExtra))
              .Where(m => price == 0 || m.Price.Equals(price))
              .OrderBy(m => m.Price);
            var pagingInfo = new PagingInfoViewModel(await extras.CountAsync(), page);

            var model = new ExtraIndexViewModel
            {
                ExtraList = new ListViewModel<Extra>
                {
                    List = await extras
                    .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                DescExtraSearched = descExtra,
                PriceSearched = price,
             
            };
            return View(model);
        }

        // GET: Extras/Details/5
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Extra == null)
            {
                return NotFound();
            }

            var extra = await _context.Extra
                .FirstOrDefaultAsync(m => m.ExtraID == id);
            if (extra == null)
            {
                return View("ExtrasNotFound");
            }
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(extra);
        }

        // GET: Extras/Create
        [Authorize(Roles = "Colaborator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Extras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Colaborator")]
        public async Task<IActionResult> Create([Bind("ExtraID,DescExtra,Price")] Extra extra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(extra);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Extra created successfully";
                return RedirectToAction(nameof(Details), new {id = extra.ExtraID});
            }
            return View(extra);
        }

        // GET: Extras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Extra == null)
            {
                return NotFound();
            }

            var extra = await _context.Extra.FindAsync(id);
            if (extra == null)
            {
                return View("ExtrasNotFound");
            }
            return View(extra);
        }

        // POST: Extras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExtraID,DescExtra,Price")] Extra extra)
        {
            if (id != extra.ExtraID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(extra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExtraExists(extra.ExtraID))
                    {
                        return View("ExtrasNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(extra);
        }

        // GET: Extras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Extra == null)
            {
                return NotFound();
            }

            var extra = await _context.Extra
                .FirstOrDefaultAsync(m => m.ExtraID == id);
            if (extra == null)
            {
                return View("ExtrasNotFound");
            }
            TempData["SuccessMessage"] = " ";
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(extra);
        }

        // POST: Extras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Extra == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Extra'  is null.");
            }
            var extra = await _context.Extra.FindAsync(id);
            if (extra != null)
            {
                //TODO : Extra was not found page
            }
            _context.Extra.Remove(extra);
            TempData["SuccessMessage"] = "Brand removed successfully.";

            await _context.SaveChangesAsync();
            return View("ExtraDeleted");
        }

        private bool ExtraExists(int id)
        {
          return _context.Extra.Any(e => e.ExtraID == id);
        }
    }
}
