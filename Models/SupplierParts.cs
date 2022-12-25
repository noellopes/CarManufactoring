using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class SupplierParts
    {
        [Key]

        public int SupplierPartsId { get; set; }

        [Display(Name = "Logo")]
        [Url]
        public string? Logo { get; set; }

        [Required(ErrorMessage = "Please enter the Name")]
        [Display(Name = "Name")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }


 

        [Required(ErrorMessage = "Please enter the Email")]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }




        [Required(ErrorMessage = "Please enter the contact")]
        [Display(Name = "Phone Number")]
        [StringLength(20, MinimumLength = 9)]
        public string Contact { get; set; }


        [Required]
        [Display(Name = "ZIP Code")]
        [StringLength(8)]
        public string ZipCode { get; set; }
 

        [Required]
        [Display(Name = "Address")]
        [StringLength(100, MinimumLength = 2)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Country")]
        [StringLength(100, MinimumLength = 2)]
        public string Country { get; set; }
    }
}



