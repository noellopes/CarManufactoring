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
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(20)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
     
        public int SectionId { get; set; }
        public Section? Section { get; set; }
    }
}
