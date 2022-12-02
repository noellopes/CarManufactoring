using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models {
    public class CarParts:Product { // CarParts inherence the attributes from Product

        //TODO: Change these attributes to something more specific to a car part.
        [Required]
        [StringLength(120, MinimumLength = 3)]
        public string PartType { get; set; } //i.e Filters, brakes, ignition, suspension, etc.

        
    }
}
