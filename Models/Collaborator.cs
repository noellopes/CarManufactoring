using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Collaborator
    {

        public int CollaboratorId { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(20)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        public int ShiftId { get; set; }

        public Shift? Shift { get; set; }

        public ICollection<CollaboratorShift>? Shifts { get; set; }

        [Required]
        public bool OnDuty { get; set; }

    }
}
