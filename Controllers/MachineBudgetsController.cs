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

namespace CarManufactoring.Controllers
{
    public class MachineBudgetsController : Controller
    {
        private readonly CarManufactoringContext _context;

        public MachineBudgetsController(CarManufactoringContext context)
        {
            _context = context;
        }

        // GET: MachineBudgets
        public async Task<IActionResult> Index()
        {
            var carManufactoringContext = _context.MachineBudget.Include(m => m.Aquisition).Include(m => m.Supplier);
            return View(await carManufactoringContext.ToListAsync());
        }

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

        // GET: MachineBudgets/Create
        public IActionResult Create()
        {
            ViewData["AquisitionId"] = new SelectList(_context.MachineAquisition, "MachineAquisitionID", "MachineAquisitionName");
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierName");
            return View();
        }

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

        public async Task<IActionResult> Comparison()
        {
            //Pega orçamento
            string queryBudget = "SELECT * FROM MachineBudget";

            //Comparação de preços
            string queryValue = "SELECT Valor FROM MachineBudget";
            List<double> price = await _context.MachineBudget.FromSqlRaw(queryValue).Select(x => x.Valor).ToListAsync();

            //Entrega Estimada
            string queryEntrega = "SELECT dataEntrega FROM MachineBudget";
            List<DateTime> entrega = await _context.MachineBudget.FromSqlRaw(queryEntrega).Select(x => x.dataEntrega).ToListAsync();

            if (price == null || price.Count <= 0)
            {
                return NotFound();
            }


            double min = price.Min();
            DateTime menorPrazo = entrega.Min();

            //Formataçao data para formato PT e remoção do horário
            string formatted = menorPrazo.ToString("dd/MM/yyyy");

            ViewData["price"] = min;
            ViewData["deadline"] = formatted;

            return View();

        }

        //
        //OK ele consegue retornaras coisas = Status Code.
        //Criar uma view generica - Varias listas
        //

        //public async Task<IActionResult> Viability
        //{

        //}
 
        private bool MachineBudgetExists(int id)
        {
          return _context.MachineBudget.Any(e => e.MachineBudgetID == id);
        }
    }
}
