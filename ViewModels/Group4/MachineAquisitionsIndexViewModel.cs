using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group4
{
    public class MachineAquisitionsIndexViewModel
    {
        public ListViewModel<MachineAquisition> MachineAquisitionsList { get; set; }

        public string? MachineAquisitionNameSearch { get; set; }
    }
}
