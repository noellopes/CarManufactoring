using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models {
    public class CarParts:Product { // CarParts inherence the attributes from Product

       
        [Required]
        [StringLength(120, MinimumLength = 3)]
        public string PartType { get; set; } //i.e Filters, brakes, ignition, suspension, etc.

        //Car - Ricardo Sousa
        public ICollection<ModelParts>? Car { get; set; }
    }
}
