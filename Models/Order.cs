using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; } = System.DateTime.Now;

        [Required]
        [Display(Name = "Order State")]
        public int OrderStateId { get; set; }
        public OrderState? OrderState { get; set; }

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
