using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Data;
using CarManufactoring.Models;
using System.Collections;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using CarManufactoring.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CarManufactoring.Controllers
{
    public class MachineBudgetsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MachineBudgetsController(CarManufactoringContext context)
        {
            _context = context;
        }

        //[Authorize(Roles = "Admin,ProdutionManager")]
        // GET: MachineBudgets
        public async Task<IActionResult> Index(string supplier = null, string machine = null, int page = 1)
        {

            var machineBudget = _context.MachineBudget.Include(m => m.Supplier).Include(m => m.Aquisition)
               .Where(m => supplier == null || m.Supplier.SupplierName.Contains(supplier))
               .Where(m => machine == null || m.Aquisition.MachineAquisitionName.Contains(machine))
               .OrderBy(m => m.Supplier.SupplierName);

            var pagingInfo = new PagingInfoViewModel(await machineBudget.CountAsync(), page);

            var model = new MachineBudgetIndexViewModel
            {
                MachineBudgetList = new ListViewModel<MachineBudget>
                {
                    List = await machineBudget
                    .Skip((pagingInfo.CurrentPage == 0 ? 0 : pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize).ToListAsync(),
                    PagingInfo = pagingInfo
                },
                SupplierSearched = supplier,
                MachineAquisitionSearched = machine
            };

            //var carManufactoringContext = _context.MachineBudget.Include(m => m.Aquisition).Include(m => m.Supplier);

            return View(model);
        }

        //[Authorize(Roles = "Admin,ProdutionManager")]
        // GET: MachineBudgets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MachineBudget == null)
            {
                return NotFound();
            }

            var machineBudget = await _context.MachineBudget
                .Include(m => m.Aquisition)
                .Include(m => m.Supplier)
                .FirstOrDefaultAsync(m => m.MachineBudgetID == id);
            if (machineBudget == null)
            {
                return NotFound();
            }

            return View(machineBudget);
        }

        //[Authorize(Roles = "Admin,ProdutionManager")]
        // GET: MachineBudgets/Create
        public IActionResult Create()
        {
            ViewData["AquisitionId"] = new SelectList(_context.MachineAquisition, "MachineAquisitionID", "MachineAquisitionName");
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierName");
            return View();
        }

        //[Authorize(Roles = "Admin,ProdutionManager")]
        // POST: MachineBudgets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineBudgetID,dataSolicitada,dataEntrega,Valor,prazoGarantia,custoManutencao,SupplierId,AquisitionId")] MachineBudget machineBudget)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machineBudget);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AquisitionId"] = new SelectList(_context.MachineAquisition, "MachineAquisitionID", "MachineAquisitionName", machineBudget.AquisitionId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierName", machineBudget.SupplierId);
            return View(machineBudget);
        }

        //[Authorize(Roles = "Admin,ProdutionManager")]
        // GET: MachineBudgets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MachineBudget == null)
            {
                return NotFound();
            }

            var machineBudget = await _context.MachineBudget.FindAsync(id);
            if (machineBudget == null)
            {
                return NotFound();
            }
            ViewData["AquisitionId"] = new SelectList(_context.MachineAquisition, "MachineAquisitionID", "MachineAquisitionName", machineBudget.AquisitionId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierName", machineBudget.SupplierId);
            return View(machineBudget);
        }

        //[Authorize(Roles = "Admin,ProdutionManager")]
        // POST: MachineBudgets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineBudgetID,dataSolicitada,dataEntrega,Valor,prazoGarantia,custoManutencao,SupplierId,AquisitionId")] MachineBudget machineBudget)
        {
            if (id != machineBudget.MachineBudgetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machineBudget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineBudgetExists(machineBudget.MachineBudgetID))
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
            ViewData["AquisitionId"] = new SelectList(_context.MachineAquisition, "MachineAquisitionID", "MachineAquisitionName", machineBudget.AquisitionId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierName", machineBudget.SupplierId);
            return View(machineBudget);
        }

        //[Authorize(Roles = "Admin,ProdutionManager")]
        // GET: MachineBudgets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MachineBudget == null)
            {
                return NotFound();
            }

            var machineBudget = await _context.MachineBudget
                .Include(m => m.Aquisition)
                .Include(m => m.Supplier)
                .FirstOrDefaultAsync(m => m.MachineBudgetID == id);
            if (machineBudget == null)
            {
                return NotFound();
            }

            return View(machineBudget);
        }

        //[Authorize(Roles = "Admin,ProdutionManager")]
        // POST: MachineBudgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MachineBudget == null)
            {
                return Problem("Entity set 'CarManufactoringContext.MachineBudget'  is null.");
            }
            var machineBudget = await _context.MachineBudget.FindAsync(id);
            if (machineBudget != null)
            {
                _context.MachineBudget.Remove(machineBudget);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> beforeComparison(MachineBudget machineBudget)
        {
            ViewData["AquisitionId"] = new SelectList(_context.MachineAquisition, "MachineAquisitionID", "MachineAquisitionName", machineBudget.AquisitionId);

            return View(machineBudget);
        }

        public async Task<IActionResult> Comparison(int AquisitionId)
        {
            //Comparação
            string queryValue = $"SELECT * FROM MachineBudget WHERE AquisitionId = {AquisitionId}";
            List<MachineBudget> machineBudgets = await _context.MachineBudget.FromSqlRaw(queryValue).Include(m => m.Aquisition).Include(s => s.Supplier).ToListAsync();

           
            if (machineBudgets == null || machineBudgets.Count() <= 0)
            {
                return NotFound();
            }

            List<MachineBudget> machineBudgetsParameters = new List<MachineBudget>();

            machineBudgetsParameters.Add(machineBudgets.Where(x => x.Valor == machineBudgets.Min(x => x.Valor)).First());
            machineBudgetsParameters.Add(machineBudgets.Where(x => x.dataEntrega == machineBudgets.Min(x => x.dataEntrega)).First());
            machineBudgetsParameters.Add(machineBudgets.Where(x => x.Aquisition.QuantityOfParts == machineBudgets.Max(x => x.Aquisition.QuantityOfParts)).First());


            return View(machineBudgetsParameters);

        }
 
        private bool MachineBudgetExists(int id)
        {
          return _context.MachineBudget.Any(e => e.MachineBudgetID == id);
        }
    }
}
