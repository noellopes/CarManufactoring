using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class MachineBrand
    {
        [Key]
        public int MachineBrandId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name ="Brand")]
        public string MachineBrandName { get; set;}

        public ICollection<MachineModel>? MachineModels { get; set; }

    }
}
