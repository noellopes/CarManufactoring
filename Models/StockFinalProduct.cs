using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace CarManufactoring.Models
{
    public class StockFinalProduct
    {

        public int LocalizationCarId { get; set; }
        public LocalizationCar? LocalizationCar { get; set; }

        public int CarConfigId { get; set; }
        public CarConfig? CarConfig { get; set; }

        [Required]
        
        public string ChassiNumber { get; set; }

        public int  ProductionId { get; set; }

        public Production? Production { get; set; }


    }
}
