using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class Production
    {
        public int ProductionId { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Required]
        [Display(Name = "Delivery Date")]
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }
    }
}
