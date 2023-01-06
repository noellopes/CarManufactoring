
using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class ShiftSchedule
    {
        [Key]
        public int ShiftSchedulesId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string Duration { get; set; }
        public int CollaboratorId { get; set; }
        public Collaborator? Collaborator { get; set; }
    }
}
