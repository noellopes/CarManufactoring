using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Brand
    {
        public int BrandId { get; set; }

        [Required]
        [Display(Name = "Brand")]
        [StringLength(50, MinimumLength = 2)]
        public string BrandName { get; set; }

        public ICollection<Car>? Cars { get; set; }
    }
}
