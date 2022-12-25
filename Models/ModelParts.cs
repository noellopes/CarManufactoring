using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class ModelParts
    {   
        public int ProductId { get; set; }
        public CarParts CarParts { get; set; }

        public int CarConfigId { get; set; }
        public CarConfig CarConfig { get; set; }

        public int QtdPecas { get; set; }
    }
}
