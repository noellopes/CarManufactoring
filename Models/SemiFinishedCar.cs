using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class SemiFinishedCar
    {
        [Key]
        public int SemiFinishedCarsId { get; set; }

        public int? SemiFinishedId { get; set; }
        public SemiFinished? SemiFinished { get; set; }

        public int? CarId { get; set; }
        public Car? Car { get; set;}
    }
}
