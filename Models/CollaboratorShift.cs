using MessagePack;
using Microsoft.EntityFrameworkCore;
namespace CarManufactoring.Models
{

    public class CollaboratorShift
    {
        public int CollaboratorId { get; set; }
        public Collaborator? Collaborator { get; set; }
        public int ShifId { get; set; }
        public Shift? Shift { get; set; }
    }
}