using Microsoft.AspNetCore.Mvc;

namespace CarManufactoring.Models
{
    public class ShiftSchedule
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
    }
}