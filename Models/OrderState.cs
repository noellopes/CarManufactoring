using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class OrderState
    {
        public int OrderStateId { get; set; }

        [Required]
        [Display(Name = "OrderState")]
        [StringLength(50, MinimumLength = 2)]
        public string OrderStateName { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
