using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group2
{
    public class WarehouseProductsIndexViewModel
    {
        public ListViewModel<WarehouseProduct> WarehouseProductsList { get; set; }
        public int? ProductSearch { get; set; }

        public int? WarehouseSearch { get; set; }

    }
}
