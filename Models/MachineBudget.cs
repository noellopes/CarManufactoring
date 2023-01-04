﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarManufactoring.Models
{

    //Orçamento de maquinas
    public class MachineBudget
    {
        public int MachineBudgetID { get; set; }

        [Required]
        [Display(Name = "Data de Solicitamento")]
        public DateTime dataSolicitada { get; set; }

        [Required]
        [Display(Name = "Data de Entrega")]
        public DateTime dataEntrega { get; set; }

        [Required]
        [Display(Name = "Valor")]
        public double Valor { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        [Display(Name = "Machine")]
        public int AquisitionId { get; set; }
        public MachineAquisition? Aquisition { get; set; }
    }
}
