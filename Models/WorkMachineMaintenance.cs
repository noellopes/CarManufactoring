using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class WorkMachineMaintenance
    {

        [Key]
        public int WorkMachineMaintenanceId { get; set; }


        [Required]
        public DateTime MaintenanceStateDate { get; set; }

        [Required]
        public string? WorkPriority { get; set; }

        [Required]
        public bool? Deleted { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime PreviewStartDate { get; set; }

        [Required]
        public int MachinesId { get; set; }
        public Machines? Machines { get; set; }
        [Required]
        public int SectionManagerId { get; set; }
        public SectionManager? SectionManager { get; set; }

        [Required]
        public int MaintenanceTaskId { get; set; }
        public MaintenanceTask? MaintenanceTask { get; set; }

        [Required]
        public int WorkStatesId { get; set; }
        public WorkStates? WorkStates { get; set; }

    }
}