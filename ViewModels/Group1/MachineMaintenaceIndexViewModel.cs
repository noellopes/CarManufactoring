using CarManufactoring.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.ViewModels.Group1
{
    public class MachineMaintenaceIndexViewModel
    {
        public ListViewModel<MachineMaintenance>  All  { get; set; }
        public IEnumerable<MachineMaintenance>  OnProgress  { get; set; }
        public ListViewModel<MachineMaintenance> OnPogressPaginated { get; set; }
        public ListViewModel<MachineMaintenance> Closed { get; set; }

        public ListViewModel<MachineMaintenance> Deleted { get; set; }

        public IEnumerable<MachineMaintenance> OpenToGraph;
        public IEnumerable<MachineMaintenance> ClosedToGraph;

        public ListViewModel <MachineMaintenance> MachineMaintenanceList { get; set; }

        public string? PrioritySearched { get; set; }

        public string? TaskTypeSearched { get; set; }

        public string? MachineSearched { get; set; }


    }
}
