
using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }        

        [Display(Name = "Machine Model")]
        public int MachineModelId { get; set; }
        [Display(Name = "Machine Model")]
        public MachineModel? MachineModel { get; set; }

        [Required]
        [Display(Name ="Machine State")]    
        public int MachineStateId { get; set; }
        public MachineState? MachineState { get; set; }

        [Display(Name = "Localization")]
        public int LocalizationCodeId { get; set; }
        public LocalizationCode? MachineLocalizationCode { get; set; }
        // public ICollection<Breakdown> Breakdowns { get; set; }

        [Required]
        [Display(Name = "Date Acquired")]
        [DataType(DataType.Date)]
        public DateTime? DateAcquired { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(160)]
        public string? Description { get; set; }


    }
}
