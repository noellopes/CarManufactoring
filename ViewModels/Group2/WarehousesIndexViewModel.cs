using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group2
{
    public class WarehousesIndexViewModel
    {
        public ListViewModel<Warehouse> WarehousesList { get; set; }
        public string? LocationSearch { get; set; }

    }
}