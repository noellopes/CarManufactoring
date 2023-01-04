using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class LocalizationCar
    {
        public int LocalizationCarId { get; set; }

        [Required]
        [Display(Name = "Line where the car is located ")]
        public string Line { get; set; }

        [Required]
        [Display(Name = "Row where the car is located ")]
        public string Row { get; set; }

        public bool IsOccupied { get; set; }

        
    }
}
