namespace CarManufactoring.Models
{
    public class WorkingHours
    {
        public int WorkingHoursId { get; set; }
        public string? WorkerName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }


    }
}
