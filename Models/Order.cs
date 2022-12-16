using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        public String OrderDate { get; set; }

        [Required]
        [Display(Name = "Order State")]
        [StringLength(25)]
        public string OrderState { get; set; }

        [Required]
        [Display(Name = "State Date")]
        public DateTime StateDate { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public ICollection<SalesLine>? CarConfig { get; set; }
    }
}
