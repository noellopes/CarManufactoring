
using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class MaintenanceTask
    {
        [Key]
        public int MaintenanceTaskId { get; set; }

        [Required]
        [Display(Name = "Task")]
        [StringLength(120)]
        public string? TaskDef { get; set; }

        public ICollection<WorkMachineMaintenance>? WorkMachineMaintenances { get; set; }
    }
}
