
using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Machines
    {
        [Key]
        public int MachinesId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string MachineBrand { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string MachineModel { get; set; }

        [Required]
        public bool Available { get; set; }
       
        [Required]  
        public DateTime AquisitionDate { get; set; }

        [Required]
        public int MachineStateId { get; set; }
    }
}
