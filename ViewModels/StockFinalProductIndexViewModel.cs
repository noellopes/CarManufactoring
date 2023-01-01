using CarManufactoring.Models;

namespace CarManufactoring.ViewModels

{
    public class StockFinalProductIndexViewModel
    {
        public ListViewModel<StockFinalProduct> StockFinalProductList { get; set; }
        public IEnumerable<LocalizationCar> LocalizationCar { get; set; }

        public IEnumerable<CarConfig> CarConfigs { get; set; }
        public string LineSearched { get; set; }

        public string CarConfigNameSearched { get; set; }
        public string RowSearched { get; set; }
        public string ChassiNumberSearched { get; set; }

        public DateTime InsertionDateSearched { get; set; }
    }
}
