using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class InspectionAndTesting
    {
        [Key]
        [Required]
        public int InspectionId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string State { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string Description { get; set; }


    }
}
