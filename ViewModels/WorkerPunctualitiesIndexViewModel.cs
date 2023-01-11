using CarManufactoring.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarManufactoring.ViewModels
{
    public class WorkerPunctualitiesIndexViewModel
    {
       public ListViewModel<WorkerPunctuality> WorkersPunctuality { get; set; } 
       
       public IEnumerable<ShiftSchedule> ShiftSchedules { get; set; }   

        public DateTime? ShiftScheduleSearched { get; set; }  
        

    }
}
