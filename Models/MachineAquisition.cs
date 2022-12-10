﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class MachineAquisition
    {
        public int MachineAquisitionID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string MachineAquisitionName { get; set; }

        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Quantity of Parts")]
        public DateTime QuantityOfParts { get; set; }

        [Required]
        [Display(Name = "Produced Parts")]
        public double ProducedParts { get; set; }

        [Required]
        [Display(Name = "Maintenance Price")]
        public double MaintenancePrice { get; set; }

        [Required]
        [Display(Name = "Operation")]
        public double Operation { get; set; }

    }
}