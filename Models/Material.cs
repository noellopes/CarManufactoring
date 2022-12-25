using System.ComponentModel.DataAnnotations;
namespace CarManufactoring.Models
{
    public class Material
    {
        public int MaterialId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Nome { get; set; }

        public string? Description { get; set; }

        [StringLength(30)]
        [Required]
        public string Type { get; set; }

        public ICollection<MaterialUsed>? MaterialUsed { get; set; }
    }
}
