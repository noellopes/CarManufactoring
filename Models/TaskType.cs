using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class TaskType
    {
        [Key]
        public int TaskTypeId { get; set; }

        
        [StringLength(30,MinimumLength = 5)]
        [Display(Name ="Type of Maintenance Task")]

        public string TaskName { get; set; }
    }
}