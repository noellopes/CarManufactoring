using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class ShiftType
    {
        [Key]
        public int ShiftTypeId { get; set; }

        [Required]
        public int ShiftTime { get; set; }

        [Required]
        [StringLength(200,MinimumLength =10)]
        public string Description { get; set; }

        public ICollection<Shift>? Shifts { get; set; }

    }
}
