using CarManufactoring.Models;
using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.ViewModels.Group1
{
    public class CrudMachineMaintenanceViewModel
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
        public TaskType? TaskType { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public int PriorityId { get; set; }
        public Priority? Priority { get; set; }

        [Required]
        [Display(Name = "Machine")]
        public int MachineId { get; set; }
        public Machine? Machine { get; set; }

        public ICollection<MaintenanceCollaborator>? MaintenanceCollection { get; set; }
        public IEnumerable<int>? CollaboratorsId { get; set; }

        public void CastToMaintenaceCrud(MachineMaintenance machineMaintenance){
            MachineMaintenanceId = machineMaintenance.MachineMaintenanceId;
            Description = machineMaintenance.Description;
            Deleted = machineMaintenance.Deleted;
            BeginDate = machineMaintenance.BeginDate;
            EffectiveEndDate = machineMaintenance.EffectiveEndDate;
            ExpectedEndDate = machineMaintenance.ExpectedEndDate;
            TaskTypeId = machineMaintenance.TaskTypeId;
            TaskType = machineMaintenance.TaskType;
            Priority = machineMaintenance.Priority;
            PriorityId = machineMaintenance.PriorityId;
            MachineId = machineMaintenance.MachineId;
            Machine = machineMaintenance.Machine;

        }
    }
}
