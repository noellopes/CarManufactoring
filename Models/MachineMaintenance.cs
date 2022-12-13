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
       
        public DateTime BeginDate { get; set; } = DateTime.Now.Date;

        public DateTime? Effective_End_Date { get; set; }

        [Required]
        public DateTime Expected_End_Date { get; set; }

        [Required]
        [Display(Name = "Task Type")]
        public int TaskTypeId { get; set; }
        public TaskType? TaskType { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public int PriorityId { get; set; }
        public Priority? Priority { get; set; }

        [Required]
        [Display(Name = "Machine")]
        public int MachineId { get; set; }
        public Machine? Machine { get; set; }


    }
}
