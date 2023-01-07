using NuGet.Protocol;

namespace CarManufactoring.Models
{
    public class WorkerPunctuality
    {
        public int WorkerPunctualityId { get; set; }
        public Collaborator Worker { get; set; }
        public string Name { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int MissedHoursLastWeek { get; set; }
        public int LateShiftsLastWeek { get; set; }

    }
}
