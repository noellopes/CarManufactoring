using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group2
{
    public class MachineAquisitionsIndexViewModel
    {
        public ListViewModel<MachineAquisition> MachineAquisitionsList { get; set; }

        public string? MachineAquisitionNameSearch { get; set; }
    }
}
