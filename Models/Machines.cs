
using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Machines
    {
        [Key]
        public int MachinesId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string Brand { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string Model { get; set; }

        [Required]
        public bool Available { get; set; }
       
        [Required]  
        public DateTime AquisitionDate { get; set; }

        [Required]
        public MachineState MachineStateId { get; set; }
    }
}
