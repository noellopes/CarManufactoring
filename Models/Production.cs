using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class Production
    {
        public int ProductionId { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        public String OrderDate { get; set; }

        [Required]
        [Display(Name = "Delivery Date")]
        [StringLength(25)]
        public string DeliveryDate { get; set; }
    }
}
