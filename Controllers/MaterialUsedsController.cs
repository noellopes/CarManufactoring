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
using System.Xml.Linq;
using System.Security.Principal;

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
        public async Task<IActionResult> Index(int id)
        {
            if (id < 0) { return NotFound("Id Error"); }
            //if (!MaterialUsedExists(id)) { return NotFound("This Semifinished does not exist in database yet"); }
            try
            {
                // Selecionar as materialUsed(quantidades) para apresentar em primeiro
                List<MaterialUsed> usedMaterials = _context.MaterialUsed.Select(mu => mu).Where(mu => mu.SemiFinishedId == id).OrderBy(mu => mu.Quantity).ToList();

                // Selecionar todos os materiais (para listar-los)
                List<Material> allMaterials = _context.Material.Select(m => m).OrderBy(m => m.Type).ToList();
                if (allMaterials.Count == 0) { return NotFound("Empty Materials List Error"); }

                // Criar um titulo com o nome do semiFinished obj
                SemiFinished? semiFinished = _context.SemiFinished.Select(mu => mu).Where(mu => mu.SemiFinishedId == id).FirstOrDefault();
                if (semiFinished == null) { return NotFound("SemiFinished not Found"); } // If semiFinished is not found

                // Meter na ViewBag
                ViewBag.SFName = string.Format("{0} ({1})", semiFinished.Family, semiFinished.Reference);
                ViewBag.MaterialUseds = usedMaterials;
                ViewBag.MaterialsAll = allMaterials;

                // Returnar a View
                return View("Index");
            }
            catch { return NotFound("Database Error"); }
        }

        // GET: MaterialUseds/Edit
        //public async Task<IActionResult> Edit(int id)
        //{
        //    if (!MaterialUsedExists(id)) { return NotFound(); }
        //    if (_context.MaterialUsed == null)
        //    {
        //        // Create a register
        //        // Retornar em pagina de success create
        //        // Pagina success create redireciona ao fim de 2/3 segundos para aqui
        //    }

        //    var materialUsed = await _context.MaterialUsed.FirstOrDefaultAsync(m => m.SemiFinishedId == id);
        //    var semiFinished = await _context.SemiFinished.FirstOrDefaultAsync(m => m.SemiFinishedId == id);
        //    var material = await _context.MaterialUsed.FirstOrDefaultAsync(m => m.MaterialUsedId == id);
        //    if (materialUsed == null) { return View("Error"); }

        //    return View("semiFinished/Index");
        //}

        private bool MaterialUsedExists(int id) => _context.MaterialUsed.Any(e => e.MaterialUsedId == id);
    }
}
