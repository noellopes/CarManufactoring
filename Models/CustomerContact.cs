using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class CustomerContact
    {
        public int CustomerContactId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(100, MinimumLength = 2)]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Customer Role")]
        [StringLength(100, MinimumLength = 2)]
        public string CustomerRole { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(13)]
        [Phone]
        public string CustomerPhone { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string CustomerEmail { get; set; }
    }
}
