using System.ComponentModel.DataAnnotations;
namespace CarManufactoring.Models
{
    public class Material
    {
        public int MaterialId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Nome { get; set; }

        [StringLength(200, MinimumLength = 10)]
        [Required]
        public string Description { get; set; }

        [StringLength(15, MinimumLength = 3)]
        [Required]
        public string State { get; set; }


        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Type { get; set; }

    }
}
