using System.ComponentModel.DataAnnotations;


namespace CarManufactoring.Models
{
    public class MachineModel
    {
        [Key]
        public int MachineModelId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Model")]
        public string MachineModelName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Brand")]

        public int MachineBrandId { get; set; }
        public MachineBrand MachineBrandNames { get; set; }
    }
}
