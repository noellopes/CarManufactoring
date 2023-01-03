using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class InspectionTestState
    {
        [Key]
        public int InspectionTestStateId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string State { get; set; }
    }
}
