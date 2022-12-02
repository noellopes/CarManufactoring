using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models {
    public abstract class Product {

        [Key] // This is needed so the program knows what is the primary key of the descendants
        public int ProductId { get; set; }

        [Required]
        [StringLength(20,MinimumLength =3)]
        public string Reference { get; set; }

        [Required]
        [StringLength(120, MinimumLength =4)]
        public string Name { get; set; }

        [Required]
        public double PointOfPurchase { get; set; }

        [Required]
        public double SafetyStock { get; set; }

        [Required]
        [Range(0,1)]
        public decimal LevelService { get; set; }

        public string StockState { get; } //Changed to method to not be inside the database

        //Methods (will be added later)
    }
}
