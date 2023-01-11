using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models {
    public class CarParts:Product { // CarParts inherence the attributes from Product

       
        [Required]
        [StringLength(120, MinimumLength = 3)]
        public string PartType { get; set; } //i.e Filters, brakes, ignition, suspension, etc.

        public ICollection<ModelParts>? CarConfig { get; set; }

        public ICollection<SupplierPartsCarParts>? SupplierParts { get; set; }
        public ICollection<PriceSupplierPartsCarParts>? SupplierParts1 { get; set; }

        public ICollection<WarehouseProduct>? Warehouses { get; set; }
    }
}
