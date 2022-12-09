using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class SemiFinishedIndexViewModel
    {
        public ListViewModel<SemiFinished> SemiFinishedList { get; set; }
        
        public string? FamilySearched { get; set; }
        
        public string? ReferenceSearched { get; set; }
        
        public string? EANSearched { get; set; }
        
        public string? ManufacterSearched { get; set; }

        public string? SemiFinishedStateSearched { get; set; }
    }
}
