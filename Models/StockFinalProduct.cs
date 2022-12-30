namespace CarManufactoring.Models
{
    public class StockFinalProduct
    {
        public int StockFinalProductId { get; set; }

        public int LocalizationCarId { get; set; }

        public LocalizationCar? LocalizationCar { get; set; }

        public string ChassiNumber { get; set; }

        public int ProductionId { get; set; }

        public Production? Production { get; set; }

        public DateTime InsertionDate { get; set; }
    }
}
