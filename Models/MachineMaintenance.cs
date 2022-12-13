using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class MachineMaintenance
    {
        
        public int MachineMaintenanceId { get; set; }
       
        [StringLength(500)]
        [Required]
        public string? Description { get; set; }

        public bool Deleted { get; set; } = false;

        public DateOnly BeginDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public DateOnly? Effective_End_Date { get; set; }

        [Required]
        public DateOnly Expected_End_Date { get; set; }

    }
}
