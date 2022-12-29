using CarManufactoring.Models;
namespace CarManufactoring.ViewModels
{
    public class CollaboratorIndexViewModel
    {
        public ListViewModel<Collaborator> collaboratorList { get; set; }
        public string? NameSearched { get; set; }
        public string? PhoneSearched { get; set; }
        public int? OnDutyFilter { get; set; }
        public int? GenderSearched { get; set; }
    }
}
