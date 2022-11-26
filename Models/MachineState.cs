using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class MachineState
    {
        public int MachineStateId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name ="Machine State")]
        public string? StateMachine { get; set; }

        public ICollection<Machines>? Machines { get; set; }

    }
}
