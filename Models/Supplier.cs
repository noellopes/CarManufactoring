using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Please enter the Name")]
        [Display(Name = "Name")]
        [StringLength(100, MinimumLength = 2)]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Please enter the Email")]
        [EmailAddress]
        [StringLength(256)]
        public string SupplierEmail { get; set; }


        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(20)]
        [Phone]
        public string SupplierContact { get; set; }


        //FilipeSantos-1702072
        [Required]
        [Display(Name = "ZIP Code")]
        [StringLength(20)]
        public string SupplierZipCode { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(100, MinimumLength = 2)]
        public string SupplierAddress { get; set; }
        //Acabou
    }
}
