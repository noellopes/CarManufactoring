using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Stock
    {
        public int StockId { get; set; }

        [Required]
        [Display(Name = "Stock quantity")]
        
        public double Quantity { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Description { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Location { get; set; }

        public int WarehouseStockId { get; set; }
        public WarehouseStock? WarehouseStock { get; set; }
        public int MaterialId { get; set; }
        public Material? Material { get; set; }
    }
}
