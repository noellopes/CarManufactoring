using System.ComponentModel.DataAnnotations;
using System.Data;

using System.ComponentModel.DataAnnotations;
namespace CarManufactoring.Models
{
    public class Shift
    {
        //chave primária
        [Key]
        public int ShiftId { get; set; }

        [Required]
        public int ShiftHours { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public ICollection<CollaboratorShift>? Collaborators { get; set; }


        [StringLength(100, MinimumLength = 10)]
        [Required]
        public string ShiftStatus { get; set; }
    }
}