using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

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


        [ForeignKey("ShiftId,CollaboratorId")]
        public virtual CollaboratorShift? CollaboratorShifts { get; set; }

    }
}