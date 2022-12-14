using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Priority
    {
        public int PriorityId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }
        public ICollection<SectionManager>? MachineMaintenance { get; set; }

    }
}
