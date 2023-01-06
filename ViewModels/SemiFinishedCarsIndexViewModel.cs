using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class SemiFinishedCarsIndexViewModel
    {
        public ListViewModel<SemiFinishedCar> SemiFinishedCarList { get; set; }

        public string? ReferenceSearchedCar { get; set; }

    }
}
