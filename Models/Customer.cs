using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(100, MinimumLength = 10)]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Foundation Date")]
        public DateTime CustomerFoundDate { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(13)]
        [Phone]
        public string CustomerContact { get; set; }
    }
}
