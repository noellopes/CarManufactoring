using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models {
    abstract class Product {

        public int ProdutoId {get; set;}

        [Required]
        [StringLength(9,MinimumLength =3)]
        public string Reference { get; set; }

        [Required]
        [StringLength(120, MinimumLength =4)]
        public string Name { get; set; }

        [Required]
        public int PointOfPurchase { get; set; }

        [Required]
        public int SafetyStock { get; set; }

        [Required]
        [Range(0,1)]
        public decimal LevelService { get; set; }

        [Required]
        public string StockState { get; set; } //String for now, will later change to it's corresponding state type

        //Methods (will be added later)
    }
}
