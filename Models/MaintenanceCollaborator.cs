using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class MaintenanceCollaborator
    {
        public int CollaboratorId { get; set; }

        public Collaborator? Collaborators { get; set; }
        [Display(Name ="Maintenance Id")]

        public int MachineMaintenanceId { get; set; }

        public MachineMaintenance? MaintenanceMachine { get; set; }

        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; } = DateTime.Now.Date;
        [Display(Name = "Date of finish")]
        [DataType(DataType.Date)]
        public DateTime? EffectiveEndDate { get; set; }

        public bool Deleted { get; set; } = false;




    }
}
