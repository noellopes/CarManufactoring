using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class TimeOfProduction
    {
        [Required]
        public int TimeOfProductionId { get; set; }

        [Required]
        public int CarConfigId { get; set; }
        public CarConfig? CarConfig { get; set; }

        [Required(ErrorMessage = "Its necessary to introduce a value!")]
        [Range(1, 30, ErrorMessage = "The number should be between 1 and 30!")]
        public int Time { get; set; }
    }
}
