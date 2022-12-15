using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class CarIndexViewModel
    {
        public ListViewModel<Car> CarsList { get; set; }

        public string? CarModelSearched {get; set; }

        public string? BrandSearched { get; set; }  

        public double? PriceSearched { get; set; }

        public int? LaunchYearSearched { get; set; }

        public int? TimeProductionSearched { get; set; }
    }
}
