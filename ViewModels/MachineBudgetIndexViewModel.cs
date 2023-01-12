using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class MachineBudgetIndexViewModel
    {
        public ListViewModel<MachineBudget> MachineBudgetList { get; set; }
        public string? SupplierSearched { get; set; }
        public string? MachineAquisitionSearched { get; set; }
    }
}
