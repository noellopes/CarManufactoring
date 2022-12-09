using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class SemiFinished
    {
        public int SemiFinishedId { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Required]
        public string Family { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Reference { get; set; }

        [StringLength(13, MinimumLength = 13)]
        [Required]
        public string EAN { get; set; }


        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Manufacter { get; set; }


        [StringLength(200, MinimumLength = 10)]
        [Required]
        public string Description { get; set; }


        [StringLength(30)]
        [Required]
        public string SemiFinishedState { get; set; }

        // relationship between SemiFinished and CARS
        public ICollection<Car> Cars { get; set; }

        // relationship between SemiFinished and INSPECTION (WAITING CREATION)
        
        // Relation between the table MaterialUsado and SemiFinished
        public ICollection<Car> MaterialUsado { get; set; }
    }
}
