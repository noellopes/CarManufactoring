using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Car
    {
        [Required]
        public int CarId { get; set; }
       
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string CarName { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string CarModel { get; set; }
        
        [Required]
        public int LaunchYear { get; set; }
        
        [Required]
        public Double BasePrice { get; set; }
    }
}
