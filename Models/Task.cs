using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required]
        public string? Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}