using System.ComponentModel.DataAnnotations;
namespace CarManufactoring.Models

{
    public class CollaboratorShift
    {
        public int CollaboratorId { get; set; }
        public Collaborator? Collaborator { get; set; }
        public int ShiftId { get; set; }
        public Shift? Shift { get; set; }

        public ICollection<CollaboratorTask>? Tasks { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

    }
}
