using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class MaterialUsado
    {
        public int MaterialId { get; set; }
        public int SemiFinishedId { get; set; }

        [Required]
        public int QuantidadeNecessaria { get; set; }
        
    }

}

