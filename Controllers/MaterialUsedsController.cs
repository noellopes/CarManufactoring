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
    public class MaterialUsedsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MaterialUsedsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: MaterialUseds
        public async Task<IActionResult> Index()
        {
              return View(await _context.MaterialUsed.ToListAsync());
        }


        private bool MaterialUsedExists(int id)
        {
          return _context.MaterialUsed.Any(e => e.MaterialUsedId == id);
        }
    }
}
