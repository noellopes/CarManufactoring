using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class MaintenanceCollaborator
    {
        public int CollaboratorId { get; set; }

        public Collaborator? Collaborators { get; set; }

        public int MachineMaintenanceId { get; set; }

        public MachineMaintenance? MaintenanceMachine { get; set; }

        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; } = DateTime.Now.Date;

        [DataType(DataType.Date)]
        public DateTime? EffectiveEndDate { get; set; } = null;

        public bool Deleted { get; set; } = false;




    }
}
