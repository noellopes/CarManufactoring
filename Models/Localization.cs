using System.ComponentModel.DataAnnotations;
namespace CarManufactoring.Models
{
    public class Localization
    {
        
        public int LocalizationId { get; set; }

        [Required]
        [Display(Name = "Line where the car is located ")]
        public  string Line  { get; set; }

         [Required]
         [Display(Name = "Row where the car is located ")]
         public string Row  { get; set; }

}
}
