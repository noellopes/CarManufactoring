using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Extra
    {
        public int ExtraID { get; set; }

        [Required]
        [Display(Name = "Description Extra")]
        [StringLength(100, MinimumLength = 2)]
        public string DescExtra { get; set; }

        [Required]
        [Display(Name = "Price")]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public double Price { get; set; }

    }
}