using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group1
{
    public class CreateMachineMaintenanceViewModel
    {

        public string? Description { get; set; }
        public int TaskTypeId { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public IEnumerable<Collaborator>? Collaborators { get; set; }
    }
}
