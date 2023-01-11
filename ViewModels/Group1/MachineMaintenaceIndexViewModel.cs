﻿using CarManufactoring.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.ViewModels.Group1
{
    public class MachineMaintenaceIndexViewModel
    {
        public ListViewModel<MachineMaintenance>  All  { get; set; }
        public IEnumerable<MachineMaintenance>  OnProgress  { get; set; }


        public ListViewModel<MachineMaintenance> MachineMaintenanceList { get; set; }

        public ListViewModel<MachineMaintenance> Deleted { get; set; }

    }
}
