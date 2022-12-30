using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class ModelPartsIndexViewModel
    {
        public ListViewModel<ModelParts> ModelPartsList { get; set; }
        public IEnumerable<CarParts> CarParts { get; set; }

        public string? ModelPartsNameSearched { get; set; }

        public string? CarConfigNameSearched { get; set; }

        public int? QuantitySearched { get; set; }
    }
}
