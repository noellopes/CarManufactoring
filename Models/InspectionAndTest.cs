using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace CarManufactoring.Models
{
    public class InspectionAndTest
    {

        
            [Key]
            [Required]
            public int InspectionId { get; set; }

            
            public int ProductionsId { get; set; }

            public Production? Productions { get; set; }

            [Required]
            public int QuantityTested { get; set; }
            

            public int StateId { get; set; }

            public InspectionTestState? State { get; set; }

            [Required]
            [StringLength(200, MinimumLength = 10)]
            public string Description { get; set; }

            [Required]
            public DateTime Date { get; set; }

            public int CollaboratorId { get; set; }

            public Collaborator? Collaborator { get; set; }


            public ICollection<InspectionTestsProduction> Production { get; set; }

            



    }
}
