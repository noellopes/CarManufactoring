using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        public int ShiftTypeId { get; set; }

        [Display(Name = "Shift Type")]
        public ShiftType? ShiftType { get; set; }

        public ICollection<CollaboratorShifts>? ShiftCollaborator { get; set; }

    }
}
