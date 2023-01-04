using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class StockIndexViewModel
    {
        public ListViewModel<Stock> StockList { get; set; }
        public string? MaterialSearched { get; set; }
        public string? WarehouseStockSearched { get; set; }
    }
}
