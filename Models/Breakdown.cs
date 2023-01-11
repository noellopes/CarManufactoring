using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;


namespace CarManufactoring.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MachineReplacement {
        Replacement,
        Repair
    }
    public class Breakdown
    {
        public int BreakdownId { get; set; }


        [Required]
        [Display(Name = "Breakdown Name ")]
        [StringLength(100, MinimumLength = 2)]
        public string BreakdownName { get; set; }

        [Required]
        [Display(Name = "Breakdown Date")]
        [DataType(DataType.Date)]
        public DateTime BreakdownDate { get; set; }

        [Required]
        [Display(Name = "Breakdown Number")]
        [Range(0, 99)]
        public int BreakdownNumber { get; set; }

        [Required]
        [Display(Name = "Reparation Date")]
        [DataType(DataType.Date)]
        public DateTime ReparationDate { get; set; }

        [Required]
        [Display(Name = "Machine Stop")]
        [Range(0,99)]
        public int MachineStop { get; set; }

        [Required]
        [Display(Name = "machine state")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MachineReplacement MachineReplacement { get; set; }

        [Display(Name = "Repair In The Company")]
        public bool RepairInTheCompany { get; set; }

       //public int MachineId { get; set; }
       // public Machine Machine? { get; set; }
    }
}
