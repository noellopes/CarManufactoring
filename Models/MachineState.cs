using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class MachineState
    {
        public int MachineStateId { get; set; }
        [Required]
        [StringLength(100)]
        public string State { get; set; }

    }
}
