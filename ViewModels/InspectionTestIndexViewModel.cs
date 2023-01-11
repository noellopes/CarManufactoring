using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class InspectionTestIndexViewModel
    {
        public ListViewModel<InspectionAndTest> InspectionAndTestList { get; set; }
        public string? ProductionsSearched { get; set; }

        public string? StateSearched { get; set; }

        public string? CollaboratorSearched { get; set; }
    }
}
