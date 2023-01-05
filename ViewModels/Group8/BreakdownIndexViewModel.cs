using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group8
{
    public class BreakdownIndexViewModel
    {
        public ListViewModel<Breakdown> BreakdownList { get; set; }

        public string? BreakdownNameSearch { get; set; }
        public string? BreakdownNumberSearch { get; set; }

    }
}
