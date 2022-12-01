using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class CarConfig
    {
        public int CarConfigId { get; set; }

        [Required]
        [Display(Name ="Name")]
        public string ConfigName { get; set; }

        [Required]
        [Range (0, int.MaxValue, ErrorMessage ="Value must be greater than zero")]
        [Display(Name = "Number of Extras")]
        public int NumExtras { get; set; }

        [Required]
        [Display(Name="Price Added")]
        [Range(0, int.MaxValue, ErrorMessage ="Value must be greater than zero")]
        public double AddedPrice { get; set; }

        [Required]
        [Display(Name ="Car")]
        public int CarId { get; set; }
        public Car? Car { get; set; }
    }
}
