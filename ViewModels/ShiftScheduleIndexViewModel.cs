using CarManufactoring.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarManufactoring.ViewModels
{
    public class ShiftScheduleIndexViewModel
    {
        public ListViewModel<ShiftSchedule> ShiftSchedules { get; set; }
        public IEnumerable<Collaborator> Collaborators { get; set; }
        public String? CollaboratorSearched { get; set; }
    }
}
