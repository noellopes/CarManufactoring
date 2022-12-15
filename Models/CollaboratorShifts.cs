using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class CollaboratorShifts
    {
        [Key]
        public int CollaboratorShiftId { get; set; }

        public DateTime? EffectiveStartDate { get; set; }

        public DateTime? EffectiveEndDate { get; set; }

        //relação many to many
        public int ShiftId { get; set; }
        public Shift? Shift { get; set; }

        public int CollaboratorId { get; set; }
        public Collaborator? Collaborator { get; set; }

    }
}
