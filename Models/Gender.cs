using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }
        [Required]
        [StringLength(30,MinimumLength =8)]
        [Display(Name ="Gender")]
        public string GenderDefinition { get; set; }
        public ICollection<Collaborator> Collaborators { get; set;}
        public ICollection<SectionManager> SectionManagers { get; set;}
    }
}
