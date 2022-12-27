using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class Production
    {
        public int ProductionId { get; set; }

        [Required]
        [Display(Name = "Production Start Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Car Configuration")]
        public int CarConfigId { get; set; }

        public CarConfig? CarConfig { get; set; }

        public int Quantity { get; set; }
    }
}
