using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class MaterialUsado
    {

        [Key]
        [Required]
        public int MaterialUsadoId { get; set; }

        [Required]
        public int MaterialId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string MaterialNome { get; set; }

        [Required]
        public int SemiFinishedId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string SemiFinishedNome { get; set; }

    }

}

