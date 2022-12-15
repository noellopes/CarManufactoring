using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class ShiftType
    {
        [Key]
        public int ShiftTypeId { get; set; }

        [Required]
        [Display(Name = "Shift Time")]
        public int ShiftTime { get; set; }

        [Required]
        [StringLength(200,MinimumLength =10)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
        public ICollection<Shift>? Shifts { get; set; }

    }
}
