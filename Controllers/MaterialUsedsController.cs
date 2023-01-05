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
using System.Runtime.InteropServices;

namespace CarManufactoring.Controllers
{
    public class MaterialUsedsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MaterialUsedsController(CarManufactoringContext context)
        {
            _context = context;
        }

        private async void Populate(int id, IEnumerable<MaterialUsed> materialUseds)
        {
            if (materialUseds.Count() == 1) { _context.Add(materialUseds); }
            else { _context.AddRange(materialUseds); }
            await _context.SaveChangesAsync();
            Index(id);
        }
        

        // GET: MaterialUseds
        public IActionResult Index(int id)
        {
            if (id < 0) { return NotFound("Id Error"); }
            //if (!MaterialUsedExists(id)) { return NotFound("This Semifinished does not exist in database yet"); }
            try
            {
                // Selecionar todos os materiais
                List<Material> allMaterials = _context.Material.Select(m => m).OrderBy(m => m.Type).ToList();
                if (allMaterials.Count == 0) { return NotFound("Empty Materials List Error"); }

                // Selecionar todos os materiais usados (ordonado pelo nome com prioridade para a quantidade)
                List<MaterialUsed> materialUsed = _context.MaterialUsed.Select(mu => mu).Where(mu => mu.SemiFinishedId == id).OrderBy(mu => mu.Material.Nome).OrderBy(mu => mu.Quantity).ToList();

                // Se um novo material for criado depois, essa adição sera feita automaticamente ma db
                if (materialUsed.Count < allMaterials.Count)
                {
                    List<MaterialUsed> materialToPopulate = new();
                    for (int i = 0; i < allMaterials.Count; i++)
                    {
                        bool have = false;
                        for (int k = 0; k < materialUsed.Count; k++)
                        { if (allMaterials[i].MaterialId == materialUsed[i].MaterialId) { have = true; break; } }
                        if (!have)
                        {
                            SemiFinished? sf = _context.SemiFinished.Select(mu => mu).Where(mu => mu.SemiFinishedId == id).FirstOrDefault();
                            materialToPopulate.Add(
                                new MaterialUsed
                                {
                                    Material = allMaterials[i],
                                    SemiFinished = sf,
                                    MaterialId = allMaterials[i].MaterialId,
                                    SemiFinishedId = id,
                                    Quantity = 0
                                });
                        }
                    }
                    if (materialToPopulate.Count > 0) { Populate(id, materialToPopulate); }
                }
                Thread.Sleep(500);
                // Criar um titulo com o nome do semiFinished obj
                SemiFinished? semiFinished = _context.SemiFinished.Select(mu => mu).Where(mu => mu.SemiFinishedId == id).FirstOrDefault();
                if (semiFinished == null) { return NotFound("SemiFinished not Found"); } // If semiFinished is not found

                // Meter na ViewBag
                ViewBag.SFName = string.Format("{0} ({1})", semiFinished.Family, semiFinished.Reference);
                ViewBag.Materials = materialUsed;

                // Returnar a View
                return View("Index");
            }
            catch { return NotFound("Go back to the list and retry, if doesn't work it's a database error"); }
        }

        private bool MaterialUsedExists(int id) => _context.MaterialUsed.Any(e => e.MaterialUsedId == id);
    }
}
