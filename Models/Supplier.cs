using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(100, MinimumLength = 2)]
        public string SupplierName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string SupplierEmail { get; set; }


        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(20)]
        [Phone]
        public string SupplierContact { get; set; }
    }
}
