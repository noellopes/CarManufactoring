using CarManufactoring.Models;
namespace CarManufactoring.ViewModels
{
    public class ShiftTypeIndexViewModel
    {
        public ListViewModel<ShiftType> ShiftTypeList { get; set; }

        public string? ShiftTypeDescriptionSearched { get; set; }
    }
}