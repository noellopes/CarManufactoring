﻿
using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Machines
    {
        [Key]
        public int MachinesId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Brand")]
        public string? MachineBrand { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name ="Model")]
        public string? MachineModel { get; set; }

        public string Description { get; set; }

        [Required]
        public bool Available { get; set; }
       
        [Required]
        [Display(Name = "Aquisition Date")]
        public DateTime AquisitionDate { get; set; }

        [Required]
        [Display(Name ="Machine State")]    
        public int MachineStateId { get; set; }
        public MachineState? MachineState { get; set; }
        [Display(Name = "Section")]
        public int SectionId { get; set; }
        public Section? Section { get; set; }

       
    }
}
