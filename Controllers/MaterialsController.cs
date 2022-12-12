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
using static System.Reflection.Metadata.BlobBuilder;

namespace CarManufactoring.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MaterialsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: Materials
        public async Task<IActionResult> Index(string nome = null, string type = null, int page = 1)
        {
            var material = _context.Material.Where(b => nome == null || b.Nome.Contains(nome))
                .Where(b => type == null || b.Type.Contains(type))
                .OrderBy(b => b.Nome);

            var pagingInfo = new PagingInfoViewModel(await material.CountAsync(), page);

            var model = new MaterialIndexViewModel
            {
                MaterialList = new ListViewModel<Material>
                {   
                    List = await material
                    .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                PagingInfo = pagingInfo
                },
                NomeSearched = nome,
                TypeSearched = type
            };

            return View(model);
        }

        // GET: Materials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Material == null)
            {
                return NotFound();
            }

            var material = await _context.Material
                .FirstOrDefaultAsync(m => m.MaterialId == id);
            if (material == null)
            {
                return View("MaterialNotFound");
            }
            ViewBag.SuccessMessage = TempData["SuccessMessage"];

            return View(material);
        }

        // GET: Materials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaterialId,Nome,Description,State,Type")] Material material)
        {
            if (ModelState.IsValid)
            {
                _context.Add(material);
                await _context.SaveChangesAsync();
                
                TempData["SuccessMessage"] = "Material created successfully.";

                return RedirectToAction(nameof(Details), new { id = material.MaterialId});
}
            return View(material);
        }

        // GET: Materials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Material == null)
            {
                return NotFound();
            }

            var material = await _context.Material.FindAsync(id);
            if (material == null)
            {
                return View("MaterialNotFound");
            }
            return View(material);
        }

        // POST: Materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaterialId,Nome,Description,State,Type")] Material material)
        {
            if (id != material.MaterialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Material successfully edited.";

                    return RedirectToAction(nameof(Details), new { id = material.MaterialId });

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.MaterialId))
                    {
                        return View("MaterialNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        // GET: Materials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Material == null)
            {
                return NotFound();
            }

            var material = await _context.Material
                .FirstOrDefaultAsync(m => m.MaterialId == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Material == null)
            {
                return Problem("Entity set 'CarManufactoringContext.Material'  is null.");
            }
            var material = await _context.Material.FindAsync(id);
            if (material != null)
            {
                
            }

            _context.Material.Remove(material);
            await _context.SaveChangesAsync();
            return View("MaterialDeleted");
        }

        private bool MaterialExists(int id)
        {
          return _context.Material.Any(e => e.MaterialId == id);
        }
    }
}
