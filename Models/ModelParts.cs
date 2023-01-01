using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class ModelParts
    {   
        public int ProductId { get; set; }
        public CarParts? CarParts { get; set; }

        public int CarConfigId { get; set; }
        public CarConfig? CarConfig { get; set; }

        [Required(ErrorMessage = "It is necessary to enter a value.")]
        [Range(1, int.MaxValue, ErrorMessage = "The value must be greater than 1.")]
        public int QtdPecas { get; set; }
    }
}
