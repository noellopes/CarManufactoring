using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class WorkStates
    {
        public int WorkStatesId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Machine State")]
        public string? StateWork { get; set; }

        public ICollection<WorkMachineMaintenance>? WorkMachineMaintenances { get; set; }
    }
}
