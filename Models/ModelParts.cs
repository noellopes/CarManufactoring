using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class ModelParts
    {   
        public int ProductId { get; set; }
        public CarParts? CarParts { get; set; }

        public int CarId { get; set; }
        public Car? Car { get; set; }

        public int QtdPecas { get; set; }
    }
}
