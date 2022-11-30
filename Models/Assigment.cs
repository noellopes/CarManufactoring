using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Assigment
    {
        [Key]
        public int AssigmentId { get; set; }

        [StringLength(200, MinimumLength = 10)]
        [Required]
        public string? Description { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string? State { get; set; }

        [Required]
        public DateTime LimitDate { get; set; }

    }
}
