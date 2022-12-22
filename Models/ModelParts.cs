using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class ModelParts
    {   
        public int StockProductId { get; set; }
        public StockProduct StockProduct { get; set; }

        public int CarConfigId { get; set; }
        public CarConfig CarConfig { get; set; }

        public int QtdPecas { get; set; }
    }
}
