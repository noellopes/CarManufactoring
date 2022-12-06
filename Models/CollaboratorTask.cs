using MessagePack;
using Microsoft.EntityFrameworkCore;
namespace CarManufactoring.Models
{
    public class CollaboratorTask
    {
        public int ShiftId { get; set; }
        public Shift? Shift { get; set; }
        public int CollaboratorId { get; set; }
        public Collaborator? Collaborator { get; set; }
        public int TaskId { get; set; }
        public Task? Task { get; set; }

    }
}