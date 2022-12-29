using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class InspectionTestsProduction
    {
        [Key]
        public int InspectionTestsProductionId { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string Lote { get; set; }

        
        
        public int InspectionId { get; set; }

        public InspectionAndTest InspectionAndTest { get; set; }



        public int ProductionId { get; set; }

        public Production Production { get; set; }

    }
}
