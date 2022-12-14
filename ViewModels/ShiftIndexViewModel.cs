using CarManufactoring.Models;
namespace CarManufactoring.ViewModels
{
    public class ShiftIndexViewModel
    {
        public ListViewModel<Shift> ShiftList { get; set; }

        public string? ShiftTypeSearched { get; set; } 
    }
}
