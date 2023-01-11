using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group4
{
    public class SupplierIndexViewModel
    {
        public ListViewModel<Supplier> SupplierList { get; set; }

        public string? SupplierNameSearch { get; set; }
        public string? SupplierEmailSearch { get; set; }
    }
}
