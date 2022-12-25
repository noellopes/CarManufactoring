using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group2 {
    public class CarPartsIndexViewModel {

        public ListViewModel<CarParts> CarPartsList { get; set; }
        
        public string? NameSearch { get; set; }
        public string? ReferenceSearch { get; set; }
        public string? TypeSearch { get; set; }
        public string? BrandSearch { get; set; }
        public string? ModelSearch { get; set; }
    }
}
