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
        public Supplier Supplier_FK { get; set; }
        public MachineAquisition Aquisition_FK { get; set; }

        [Required]
        [Display(Name = "Data de Solicitamento")]
        public DateTime dataSolicitada { get; set; }

        [Required]
        [Display(Name = "Data de Entrega")]
        public DateTime dataEntrega { get; set; }

        [Required]
        [Display(Name = "Valor")]
        public double Valor { get; set; }
    }
}
