using NuGet.Protocol;

namespace CarManufactoring.Models
{
    public class WorkerPunctuality
    {
        public int WorkerPunctualityId { get; set; }
        public Collaborator Worker { get; set; }
        public int WeekNumber { get; set; }
        public int MissedHoursLastWeek { get; set; }
        public int LateShiftsLastWeek { get; set; }

    }
}
