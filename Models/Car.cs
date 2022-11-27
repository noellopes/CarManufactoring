using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace CarManufactoring.Models
{
    public class Car
    {
        [Required]
        public int CarId { get; set; }
       
        [Required]
        [Display(Name= "Name")]
        [StringLength(100, MinimumLength = 4)]
        public string CarName { get; set; }
        
        [Required]
        [Display(Name ="Model")]
        [StringLength(100, MinimumLength = 4)]
        public string CarModel { get; set; }

        //TODO : Get help if it is possible to use SystemDate 
        //static System.DateTime systemDate = System.DateTime.Now;
        //static int DateYear = systemDate.Year;

        [Required]
        [Display(Name = "Year of Launch")]
        [Range(2023, maximum: 2023, ErrorMessage = "Must be between 1950 and 2023")]
        public int LaunchYear { get; set; } = System.DateTime.Now.Year;        
        
        [Required]
        [Display(Name ="Base Price")]
        public Double BasePrice { get; set; }
    }
}
