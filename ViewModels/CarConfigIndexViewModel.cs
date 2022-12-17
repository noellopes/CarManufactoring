using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class CarConfigIndexViewModel
    {
        public ListViewModel<CarConfig> CarConfigsList { get; set; }

        public string? ConfigNameSearched { get; set; }

        public double? AddedPriceSearched { get; set; }

        public int? NumExtrasSearched { get; set; } 

        public string? CarSearched { get; set; } 
    }
}
