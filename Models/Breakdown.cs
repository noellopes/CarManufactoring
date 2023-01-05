﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class Breakdown
    {
        public int BreakdownId { get; set; }


        [Required]
        [Display(Name = "Breakdown Name ")]
        [StringLength(100, MinimumLength = 2)]
        public string BreakdownName { get; set; }

        [Required]
        [Display(Name = "Breakdown Date")]
        public DateTime BreakdownDate { get; set; }

        [Required]
        [Display(Name = "Breakdown Number")]
        [Range(0, 99)]
        public int BreakdownNumber { get; set; }

        [Required]
        [Display(Name = "Reparation Date")]
        public DateTime ReparationDate { get; set; }

        [Required]
        [Display(Name = "Machine Stop")]
        [Range(0,99)]
        public int MachineStop { get; set; }

        [Required]
        [Display(Name = "Machine Replacement")]
        [StringLength(100, MinimumLength = 2)]
        public string MachineReplacement { get; set; }

        [Display(Name = "Repair In The Company")]
        public bool RepairInTheCompany { get; set; }

       // public int MachineId { get; set; }
       // public Machine Machine { get; set; }
    }
}
