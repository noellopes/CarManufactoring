using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int ShiftTypeId { get; set; }

        public ShiftType? ShiftType { get; set; }

    }
}
