using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManufactoring.Models
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime StartDate { get; set; }

        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        public int ShiftTypeId { get; set; }

        [Display(Name = "Shift Type")]
        public ShiftType? ShiftType { get; set; }

        [NotMapped]
        [Required]
        public int Month { get; set; }

        [NotMapped]
        [Required]
        public int Year { get; set; }

        public ICollection<CollaboratorShifts>? ShiftCollaborator { get; set; }

    }
}
