using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class SemiFinishedCar
    {

        public int? SemiFinishedId { get; set; }
        public SemiFinished? SemiFinished { get; set; }

        public int? CarId { get; set; }
        public Car? Car { get; set;}
    }
}
