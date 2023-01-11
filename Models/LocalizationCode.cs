using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class LocalizationCode
    {

        [Key]
        public int LocalizationCodeId { get; set; }


        [StringLength(1)]
        [Required(ErrorMessage = "Please Enter Column position!")]
        public string Column { get; set; }

        [StringLength(1)]
        [Required(ErrorMessage = "Please Enter Line position!")]
        public string Line { get; set; }
        public ICollection<Machine> MachineLocalization { get; set;}
    }
}
