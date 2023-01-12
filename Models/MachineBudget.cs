using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarManufactoring.Models
{

    //Orçamento de máquinas
    public class MachineBudget
    {
        public int MachineBudgetID { get; set; }

        [Required]
        [Display(Name = "Request Date")]
        public DateTime dataSolicitada { get; set; }

        [Required]
        [Display(Name = "Delivery Date")]
        public DateTime dataEntrega { get; set; }

        [Required]
        [Display(Name = "Price €")]
        public double Valor { get; set; }

        [Required]
        [Display(Name = "Warranty (month)")]
        public int prazoGarantia { get; set; }

        [Required]
        [Display(Name = "Maintenance cost (by Supplier)")]
        public double custoManutencao { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        [Display(Name = "Machine")]
        public int AquisitionId { get; set; }
        public MachineAquisition? Aquisition { get; set; }

        //to be replaced
        //Machine to be replaced
        //Machine to be aquisition
    }
}
