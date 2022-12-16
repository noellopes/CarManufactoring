using CarManufactoring.Models;
namespace CarManufactoring.ViewModels
{
    public class CollaboratorIndexViewModel
    {
        public ListViewModel<Collaborator> collaboratorList { get; set; }
        public string? NameSearched { get; set; }

        //public string? GenderSearched { get; set; }

        //public string? TaskSearched { get; set; }

        //public string? StatusSearched { get; set; }
    }
}
