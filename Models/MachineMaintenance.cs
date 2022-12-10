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

        public DateTime BeginDate { get; set; } = DateTime.Now;

        public DateTime? Effective_End_Date { get; set; }

        [Required]
        public DateTime Expected_End_Date { get; set; }

    }
}
