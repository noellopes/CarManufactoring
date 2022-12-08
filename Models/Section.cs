using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }
        public ICollection<SectionManager>? Manager { get; set; }
        public ICollection<Machines>? Machines { get; set; }

    }
}
