using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class SectionManager
    {
        public int SectionManagerId { get; set; }


        [StringLength(100, MinimumLength = 20)]
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name ="Gender")]
        public int GenderId { get; set; }
        public Gender? Gender { get; set; }
       
        [Required]
        [StringLength(20)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string? Email { get; set; }

        [Required]
        [Display(Name ="Section")]
        public int SectionId { get; set; }
        public Section? Section { get; set; }

      
    }
}
