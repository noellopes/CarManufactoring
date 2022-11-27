using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Car
    {
        public int CarId { get; set; }
       
        [Required]
        [Display(Name= "Name")]
        [StringLength(100, MinimumLength = 2)]
        public string CarName { get; set; }
        
        [Required]
        [Display(Name ="Model")]
        [StringLength(100, MinimumLength = 2)]
        public string CarModel { get; set; }

        [Required]
        [Display(Name = "Year of Launch")]
        public int LaunchYear { get; set; } = System.DateTime.Now.Year;     
        
        [Required]
        [Display(Name ="Base Price")]
        [Range(0,int.MaxValue, ErrorMessage ="Price must be greater than zero")]
        public double BasePrice { get; set; }
        
        public ICollection<CarConfig>? CarConfigs { get; set; }
    }
}
