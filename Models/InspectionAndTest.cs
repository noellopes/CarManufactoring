using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace CarManufactoring.Models
{
    public class InspectionAndTest
    {

        
            [Key]
            [Required]
            public int InspectionId { get; set; }

            [Required]
            public DateTime Date { get; set; }

            [Required]
            [StringLength(20, MinimumLength = 3)]
            public string State { get; set; }

            [Required]
            [StringLength(200, MinimumLength = 10)]
            public string Description { get; set; }


            public int CollaboratorId { get; set; }

            public Collaborator? Collaborator { get; set; }

            



    }
}
