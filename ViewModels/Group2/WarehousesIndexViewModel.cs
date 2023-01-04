using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group2
{
    public class WareHousesIndexViewModel
    {
        public ListViewModel<Warehouse> WarehousesList { get; set; }
        public string? LocationSearch { get; set; }
        public int? CollaboratorSearch { get; set; }

    }
}