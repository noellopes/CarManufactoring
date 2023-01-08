using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group1
{
    public class MaintenanceCollaboratorViewModel
    {
      
        public ListViewModel<MaintenanceCollaborator> MaintenanceCollaboratorList { get; set; }
        public int? CollaboratorWorkState { get; set; }
    }
}
