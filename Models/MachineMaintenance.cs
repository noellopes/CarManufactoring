using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class MachineMaintenance
    {
        [Display(Name = "Id")]
        public int MachineMaintenanceId { get; set; }
       
        [StringLength(500)]
        [Required]
        [Display(Name = "Descrição")]
        public string? Description { get; set; }

        public bool Deleted { get; set; } = false;

        [Display(Name = "Data de Início")]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; } = DateTime.Now.Date;
        
        [DataType(DataType.Date)]
        [Display(Name = "Data de Término")]
        public DateTime? EffectiveEndDate { get; set; }

        [Display(Name = "Data Prevista")]
        [Required]
        [DataType(DataType.Date)]

        public DateTime ExpectedEndDate { get; set; }

        [Required]
        [Display(Name = "Task Type")]
        public int TaskTypeId { get; set; }
        [Display(Name = "Task Type")]
        public TaskType? TaskType { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public int PriorityId { get; set; }
        public Priority? Priority { get; set; }

        [Required]
        [Display(Name = "Machine")]
        public int MachineId { get; set; }
        public Machine? Machine { get; set; }

        public ICollection <MaintenanceCollaborator> MaintenanceCollection { get; set; }

    }
}
