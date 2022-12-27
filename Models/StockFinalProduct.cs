
using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class StockFinalProduct
    {
        [Key]

        public int LocalizationCarId { get; set; }
        public LocalizationCar? LocalizationCar { get; set; }

        

        [Required]
        
        public string ChassiNumber { get; set; }

        public int  ProductionId { get; set; }

        public Production? Production { get; set; }


    }
}
