using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class WarehouseStock
    {
        public int WarehouseStockId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Identification { get; set; }
        public ICollection<Stock>? Stocks { get; set; }
        
    }
}
