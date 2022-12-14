namespace CarManufactoring.Models
{
    public class AttendedHours
    {
        public int AttendedHoursId { get; set; }
        public string? WorkerName { get; set; }
        public int WorkedHour { get; set; }
        public DateTime CheckedIn { get; set; }
        public DateTime CheckedOut { get; set; }

        public string? workingStatus { get; set; }
        public bool IsAttended { get; set; }



    }

}
