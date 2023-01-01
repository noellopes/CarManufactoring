using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class ExtraIndexViewModel
    {

        public ListViewModel<Extra> ExtraList { get; set; }

        public string? DescExtraSearched { get; set; }

        public double? PriceSearched { get; set; }

    }
}
