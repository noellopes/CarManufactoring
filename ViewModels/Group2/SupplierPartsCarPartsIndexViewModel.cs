using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group2
{
    public class SupplierPartsCarPartsIndexViewModel
    {
        public ListViewModel<SupplierPartsCarParts> SupplierPartsCarPartsList { get; set; }

        public int? SupplierId { get; set; }

        public int? ProductId { get; set; }
    }
}