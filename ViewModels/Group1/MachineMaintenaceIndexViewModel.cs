using CarManufactoring.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.ViewModels.Group1
{
    public class MachineMaintenaceIndexViewModel
    {
        public IEnumerable<MachineMaintenance>  All  { get; set; }
        public IEnumerable<MachineMaintenance>  OnProgress  { get; set; }

    }
}
