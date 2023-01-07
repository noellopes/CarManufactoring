using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group1
{
    public class CreateMachineMaintenanceViewModel
    {

        public int MachineMaintenanceId { get; set; }
        public string? Description { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime BeginDate { get; set; } = DateTime.Now.Date;
        public DateTime? EffectiveEndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public int TaskTypeId { get; set; }
        public TaskType? TaskType { get; set; }
        public int PriorityId { get; set; }
        public Priority? Priority { get; set; }
        public int MachineId { get; set; }
        public Machine? Machine { get; set; }
        public ICollection<MaintenanceCollaborator> MaintenanceCollection { get; set; }
        public IEnumerable<Collaborator>? Collaborators { get; set; }
    }
}
