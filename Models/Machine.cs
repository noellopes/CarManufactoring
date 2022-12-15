
using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }

        [Required]
        [Display(Name = "Date Acquired")]
        [DataType(DataType.Date)]
        public DateTime DateAcquired { get; set; }

        [Display(Name = "Machine Model")]
        public int MachineModelId { get; set; }
        public MachineModel? MachineModel { get; set; }

        [Required]
        [Display(Name ="Machine State")]    
        public int MachineStateId { get; set; }
        public MachineState? MachineState { get; set; }
        [Display(Name = "Section")]
        public int SectionId { get; set; }
        public Section? Section { get; set; }

       
    }
}
