using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group1
{
    public class MaintenanceCollaboratorViewModel
    {
        public IEnumerable<MaintenanceCollaborator>? Finished { get; set; }
        public IEnumerable<MaintenanceCollaborator> Unfinished { get; set; }
    }
}
