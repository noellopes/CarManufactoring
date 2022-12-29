namespace CarManufactoring.Models
{
    public class TimeOfProduction
    {
        public int TimeOfProductionId { get; set; }

        public int CarConfigId { get; set; }
        public CarConfig CarConfig { get; set; }

        public int Time { get; set; }
    }
}
