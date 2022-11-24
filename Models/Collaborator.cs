using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models {
    public class Collaborator {

        public int CollaboratorId { get; set; }

        [Required]
        [StringLength(100, MinimumLength =1)]
        public string Name { get; set; }

        [Required]
        
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(20)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        public bool Available { get; set; }

    }
}
