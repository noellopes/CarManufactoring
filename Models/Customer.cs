using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(100, MinimumLength = 2)]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Foundation Date")]
        public DateTime CustomerFoundDate { get; set; }

        public ICollection<CustomerContact>? CustomerContacts { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
