using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group2
{
    public class SupplierPartsIndexViewModel
    {
        public ListViewModel<SupplierParts> SupplierPartsList { get; set; }

        public string? NameSearch { get; set; }
        public string? CountrySearch { get; set; }
        public string? EmailSearch { get; set; }
    }
}
